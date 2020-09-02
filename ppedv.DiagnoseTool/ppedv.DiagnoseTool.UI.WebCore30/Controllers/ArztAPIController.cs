using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ppedv.DiagnoseTool.Logik;
using ppedv.DiagnoseTool.Model;
using ppedv.DiagnoseTool.UI.WebCore30.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.DiagnoseTool.UI.WebCore30.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArztAPIController : ControllerBase
    {
        Core core = new Core(new Data.Ef.EfRepository());


        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Arzt, ArztAPI>().ForMember(x => x.Fachrichtung, aa => aa.MapFrom(s => s.FacharztRichtung)).ReverseMap();

        });
        public ArztAPIController()
        {

        }

        // GET: api/<ArztAPIController>
        [HttpGet]
        public IEnumerable<ArztAPI> Get()
        {
            var arztListe = core.Repository.Query<Arzt>().OrderBy(x => x.Name).ToList();

            foreach (var a in arztListe)
            {
                //yield return new ArztAPI() { Id = a.Id, Fachrichtung = a.Betriebsstättennummer, Name = a.Name, Patienten = a.Diagnosen.Select(x => x.Patient.Name).Distinct() };
                yield return config.CreateMapper().Map<ArztAPI>(a);
            }
        }


        // GET api/<ArztAPIController>/5
        [HttpGet("{id}")]
        public ArztAPI Get(int id)
        {
            var r = core.Repository.Query<Arzt>().FirstOrDefault(x => x.Id == id);
            return config.CreateMapper().Map<ArztAPI>(r);
        }

        // POST api/<ArztAPIController>
        [HttpPost]
        public void Post([FromBody] ArztAPI arztAPI)
        {
            var arzt = config.CreateMapper().Map<Arzt>(arztAPI);
            core.Repository.Add(arzt);
            core.Repository.SaveAll();
        }

        // PUT api/<ArztAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ArztAPI value)
        {
            var arzt = config.CreateMapper().Map<Arzt>(value);
            core.Repository.Update(arzt);
            core.Repository.SaveAll();
        }

        // DELETE api/<ArztAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var r = core.Repository.Query<Arzt>().FirstOrDefault(x => x.Id == id);
            core.Repository.Delete(r);
            core.Repository.SaveAll();
        }
    }
}
