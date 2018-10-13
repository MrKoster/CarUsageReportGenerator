# CarUsageReportGenerator

Summary:
CarUsageReportGenerator is a project that allows to generate car usage report automatically.
For now only Polish version of report is avaliable.

Please note that: 
- This project was made for fun. Since content is semi-randomly generated, do not use this to file accual car reports.
- Always fill your accual car report thoroughly with true information.

Description:
- CarUsageReportGenerator is a WPF application.
- Using it is pretty simple, run it, choose a year and month and click "Generuj",
new car report (in pdf) should generate itself in bin folder.
- Application determines which days are work days in given month, and generates rows only for those days
(basically it ommits weekends)
- Name of generated report consists of "kilometrowka_" prefix and suffix made of current date and time (yyyyMMddHHmmss format)
- Generated information is semi-random. For each row: template is randomly chosen, 
and final information for given row is randomly chosen from this template.
- Information generated in header is hardcoded in class CarInfoRepository. In future, it will be importable and/or editable by user in runtime.
- Header information consists of: DriverNameAndSurname, FullCompanyName, CompanyStreet_PartOne,
CompanyStreet_PartTwo, CarLicencePlate, CarModelName, CarEngineCapacity, CostRateValue
- Templates are objects that consist of following information: RouteDescriptions, TravelPurposes, MinKilometers, MaxKilometers
- For now there is only one template hardcoded into application (class CarUsageTemplatesRepository). 
In future there will be a possiblity to create custom templates by user (of course You can modify hardcoded template for Your own use if You want, it should work fine)
- Enjoy

