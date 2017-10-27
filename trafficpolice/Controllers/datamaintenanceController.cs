﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trafficpolice.Models;
using Newtonsoft.Json;
using perfectmsg.dbmodel;

namespace trafficpolice.Controllers
{
    public class datamaintenanceController : Controller
    {
        public readonly ILogger<datamaintenanceController> _log;
        private readonly tpContext _db1 = new tpContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db1.Dispose();
            }
            base.Dispose(disposing);
        }
        public datamaintenanceController(ILogger<datamaintenanceController> log)
        {
            _log = log;
        }
    
        [Route("addDataItem")]
        [HttpPost]
        public commonresponse addDataItem([FromBody] dataitemAddreq input)
        {
            try
            {
                if (input == null)
                {
                    _log.LogInformation("login,{0}", responseStatus.requesterror);
                    return global.commonreturn(responseStatus.requesterror);
                }
                var accinfo = global.GetInfoByToken(Request.Headers);
                if (accinfo.status != responseStatus.ok) return accinfo;
                var unit = _db1.Unit.FirstOrDefault(c => c.Id == accinfo.unitid);
                if (unit == null)
                {
                    return global.commonreturn(responseStatus.nounit);
                }
                if (unit.Level)
                {
                    return global.commonreturn(responseStatus.forbidden);
                }
               if(string.IsNullOrEmpty(input.name))
                {
                    return global.commonreturn(responseStatus.requesterror);
                }
                var thevs = _db1.Dataitem.FirstOrDefault(c => c.Name == input.name );
                if (thevs!=null)
                {
                    return global.commonreturn(responseStatus.dataitemallreadyexist);
                }
                var second = input.secondlist == null || input.secondlist.Count == 0 ? string.Empty : JsonConvert.SerializeObject(input.secondlist);
                var comment = string.IsNullOrEmpty(input.comment) ? string.Empty : input.comment;
                _db1.Dataitem.Add(new Dataitem
                {
                    Time=DateTime.Now,
                    Datatype=(short)input.dataItemType,
                    Name=input.name,
                    Deleted=false,
                    Seconditem=second,
                    Unitdisplay=input.unitdisplay,
                    Comment=input.comment,
                    Mandated=input.mandated,
                });
                _db1.SaveChanges();
                return global.commonreturn(responseStatus.ok);
            }
            catch (Exception ex)
            {
                _log.LogError("{0}-{1}-{2}", DateTime.Now, "addDataItem", ex.Message);
                return new commonresponse { status = responseStatus.processerror, content = ex.Message };
            }
        }    

      
    }
}