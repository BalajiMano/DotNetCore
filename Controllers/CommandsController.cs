using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Data;
using AutoMapper;

using Commander.Dtos;
namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _reporsitory;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo reporsitory, IMapper mapper)
        {
            _reporsitory = reporsitory;
            _mapper = mapper;
        }

        //MockCommanderRepo reporsitory = new MockCommanderRepo();
        // [HttpGet]
        // public  ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        // {
        //     var CommandItems = _reporsitory.GetAllCommands();
          

        //     if (CommandItems != null)
        //     {
        //         return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(CommandItems));
        //     }
        //     return NotFound();
        // }
[HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
             Console.WriteLine($"Thread Id before GetAsync is {Thread.CurrentThread.ManagedThreadId}");
        string _res= await GetGoogle();
        List<string> _list=new List<string>(){"Bala","Anu"};
        var _enu=_list.Where(li=>li.Length==4).Select(li=>li);
        foreach(string _str in _enu)
        {
            Console.WriteLine($"Name which are more than 4 characters {_str}");
        }

          Console.WriteLine($"Thread Id after GetAsync is {Thread.CurrentThread.ManagedThreadId} String count {_res.Length}");
return Thread.CurrentThread.ManagedThreadId.ToString();
        }

        public async Task<string> GetGoogle()
        {
              HttpClient _Client=new HttpClient();
               Console.WriteLine($"Thread Id GetGoogle before async is {Thread.CurrentThread.ManagedThreadId}");
            var _task =await _Client.GetAsync("https://youtube.com");
            _task.EnsureSuccessStatusCode();
            var _res="google";
            if(_task.IsSuccessStatusCode)
            {
        Console.WriteLine($"Thread Id GetGoogle after async is {Thread.CurrentThread.ManagedThreadId}");
         _res= await _task.Content.ReadAsStringAsync();
                     Console.WriteLine($"Thread Id GetGoogle after read response is {Thread.CurrentThread.ManagedThreadId}");
            }
return _res;
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var CommandItem = _reporsitory.GetCommandById(id);
            if (CommandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(CommandItem));
            }
            return NotFound();

        }
//Post api/Command/{id}
        [HttpPost("{id}")]
        public ActionResult<CommandReadDto> CreateCommand(int Token,int iden,CommandCreateDto commandCreateDto)
        {
            Console.WriteLine(Token);
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _reporsitory.CreateCommand(commandModel);
            _reporsitory.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);

            //return Ok(commandReadDto);
        }

        //Put api/Commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _reporsitory.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _reporsitory.UpdateCommand(commandModelFromRepo);
            _reporsitory.SaveChanges();
            return NoContent();
        }
    }

}
