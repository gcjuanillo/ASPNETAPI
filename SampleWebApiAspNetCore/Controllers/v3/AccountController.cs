using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Services;
using WebApiAspNetCore.Dtos;
using WebApiAspNetCore.Entities;
using WebApiAspNetCore.Repositories;

namespace WebApiAspNetCore.Controllers.v3
{
    [ApiController]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILinkService<AccountController> _linkService;

        public AccountController(
            IAccountRepository accountRepository,
            IMapper mapper,
            ILinkService<AccountController> linkService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _linkService = linkService;
        }


        [HttpGet(Name = nameof(GetAllAccount))]
        public ActionResult GetAllAccount()
        {
            List<AccountEntity> accountItems = _accountRepository.GetAll().ToList();

            List<AccountDto> accountDtos = _mapper.Map<List<AccountDto>>(accountItems);

            return Ok(accountDtos);
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingleAccount))]
        public ActionResult GetSingleAccount(ApiVersion version, int id)
        {
            AccountEntity accountItem = _accountRepository.GetSingle(id);

            if (accountItem == null)
            {
                return NotFound();
            }

            AccountDto account = _mapper.Map<AccountDto>(accountItem);

            return Ok(_linkService.ExpandSingleFoodItem(account, account.Id, version));
        }

        [HttpPost(Name = nameof(AddAccount))]
        public ActionResult<AccountDto> AddAccount(ApiVersion version, [FromBody] AccountCreateDto accountCreateDto)
        {
            if (accountCreateDto == null)
            {
                return BadRequest();
            }

            AccountEntity toAdd = _mapper.Map<AccountEntity>(accountCreateDto);

            _accountRepository.Add(toAdd);

            if (!_accountRepository.Save())
            {
                throw new Exception("Creating a account failed on save.");
            }

            AccountEntity newAccount = _accountRepository.GetSingle(toAdd.Id);
            AccountDto accountDto = _mapper.Map<AccountDto>(newAccount);

            return CreatedAtRoute(nameof(GetSingleAccount),
                new { version = version.ToString(), id = newAccount.Id },
                _linkService.ExpandSingleFoodItem(accountDto, accountDto.Id, version));
        }

        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateAccount))]
        public ActionResult<AccountDto> UpdateAccount(ApiVersion version, int id, [FromBody] AccountUpdateDto accountUpdateDto)
        {
            if (accountUpdateDto == null)
            {
                return BadRequest();
            }

            var existingAccount = _accountRepository.GetSingle(id);

            if (existingAccount == null)
            {
                return NotFound();
            }

            _mapper.Map(accountUpdateDto, existingAccount);

            _accountRepository.Update(id, existingAccount);

            if (!_accountRepository.Save())
            {
                throw new Exception("Updating an acccount failed on save.");
            }

            AccountDto accountDto = _mapper.Map<AccountDto>(existingAccount);

            return Ok(_linkService.ExpandSingleFoodItem(accountDto, accountDto.Id, version));
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(RemoveAccount))]
        public ActionResult RemoveAccount(int id)
        {
            AccountEntity account = _accountRepository.GetSingle(id);

            if (account == null)
            {
                return NotFound();
            }

            _accountRepository.Delete(id);

            if (!_accountRepository.Save())
            {
                throw new Exception("Deleting an account failed on save.");
            }

            return NoContent();
        }

        
    }
}
