# BusinessObject in StimulSoft

One of the methods of show reports without direct connection to the database is to use Business object 

This is  a very esay simple application ReportBusinessObject to and .Net7 and StimulSoft For Learn

## Defined BusinessObject in StimulSoft
   A Business object is an object of the data class that can be used to represent data in various structures :tables, lists, arrays, etc.  


|Tech Specification|
|--|
|EFCore7|
|MVC|
|Net7|



## In this section, a sample code for the implementation of Use  BusinessObject in Stimulsoft (the complete code is available in the project)   
```csharp   
   private readonly IHostEnvironment _hostEnvironment;
private readonly IUnitOfWork unitOfWork;
private readonly IMapper _mapper;
public ReportsController(IUnitOfWork unitOfWork, IMapper mapper, IHostEnvironment hostEnvironment)
{
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment; // has ContentRootPath property
}
```

Action:
```csharp  
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

```

Index.cshtml
```csharp  
@using Stimulsoft.Report.Mvc;
@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

@Html.StiNetCoreViewer(new StiNetCoreViewerOptions()
 {
    Actions =
    {
            GetReport = "GetReport",
             ViewerEvent = "ViewerEvent"
   }
 })
```
