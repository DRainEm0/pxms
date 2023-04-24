using BackendApi.Contracts.Account;
using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Возвращает список со всеми пользоватлями
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Account> accounts = await _userService.GetAll();
            return Ok(accounts.Select(account => account.Adapt<GetUserResponse>()));
        }
        /// <summary>
        /// Возвращает данные пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           Account account = await _userService.GetById(id);
            return Ok(account.Adapt<GetUserResponse>());
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "login" : "drDen4ik",
        ///         "password" : "!Pa$$word123@",
        ///         "phone" : "8800228322",
        ///         "email" : "tohaunyakawai@gmail.com",
        ///         "name" : "Иван",
        ///         "surname" : "Иванов",
        ///         "photo" : "https://konachan.net/image/8592605015fa32d1541d526eedc3de4f/Konachan.com%20-%2054261%20jpeg_artifacts%20remilia_scarlet%20touhou%20vampire%20wings.jpg"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            var userDto = new Account()
            {
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                Name = user.Name,
                Surname = user.Surname,
            };
            await _userService.Create(user.Adapt<Account>());
            return Ok();
        }
        /// <summary>
        /// Обновляет данные пользователя
        /// </summary>
        /// <param name="user">Пользователь c изменными данными</param>
        [HttpPut]
        public async Task<IActionResult> Update(Account user)
        {
            await _userService.Update(user.Adapt<Account>());
            return Ok();
        }
        /// <summary>
        /// Удаляет пользователя по его id
        /// </summary>
        /// <param name="id">id пользователя</param>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
