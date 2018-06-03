using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNetIdentityApp.Models;

namespace Schedule
{
    [Authorize]
    public class ValuesController : ApiController
    {
        ScheduleManager SM = new ScheduleManager();

        // GET api/values/5
        [HttpGet]
        [Route("api/values/getschedule")]
        public TableCell[,] GetSchedule(int num, int filter)
        {
            Table newTable = new Table(num, filter);
            return newTable.Cells;
        }

        [HttpGet]
        [Route("api/values/geteachers")]
        public List<TeacherViewModel> GetTeachers()
        {
            var list = new List<TeacherViewModel>();
            foreach (var elem in SM.GetAllTeachers())
                list.Add(new TeacherViewModel() { Id = elem.Id, Name = elem.Name });

            return list;
        }

        [HttpGet]
        [Route("api/values/getsubjects")]
        public List<SubjectViewModel> GetSubjects()
        {
            var list = new List<SubjectViewModel>();
            foreach (var elem in SM.GetAllSubjects())
                list.Add(new SubjectViewModel() { Id = elem.Id, Name = elem.Name });

            return list;
        }

        [HttpPost]
        [Route("api/values/addgroup/{number}")]
        public void AddGroup(int number)
        {
            SM.AddElement(number);
        }

        [HttpPost]
        [Route("api/values/addteacher/{name}")]
        public void AddTeacher(string name)
        {
            SM.AddElement(-1, name, false);
        }

        [HttpPost]
        [Route("api/values/addsubject/{name}")]
        public void AddSubject(string name)
        {
            SM.AddElement(-1, name, true);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/values/editteacher/{id}/{name}")]
        public void EditTeacher(int id, string name)
        {
            SM.EditElement(id, name, false);
        }

        [HttpPut]
        [Route("api/values/editsubject/{id}/{name}")]
        public void EditSubject(int id, string name)
        {
            SM.EditElement(id, name, true);
        }

        // DELETE api/values/5
        [Route("api/values/delete/{type}/{id}")]
        public void DeleteElement(int type, int id)
        {
            switch(type)
            {
                case 0: SM.DeleteGroup(id); break;
                case 1: SM.DeleteElement(id, true); break;
                case 2: SM.DeleteElement(id, false); break;
            }
        }
    }
}
