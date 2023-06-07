using AutoMapper;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Security.Cryptography.Xml;

namespace UI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        public ReportsController(IUnitOfWork unitOfWork, IMapper mapper, IHostEnvironment hostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment; // has ContentRootPath property

        }


        public IActionResult Index()
        {
            return View();

        }

        public IActionResult GetReport()
        {

            var report = new StiReport();
            report.Load(_hostEnvironment.ContentRootPath + @"\Reports\ReportTest.mrt");
            report.RegBusinessObject("Employee", unitOfWork.Employee.GetAll());
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
