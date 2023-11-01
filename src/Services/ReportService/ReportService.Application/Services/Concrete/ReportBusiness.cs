using AutoMapper;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ReportService.Application.Models;
using ReportService.Application.Services.Abstract;
using ReportService.Domain.Enitites;
using ReportService.Domain.Enums;
using ReportService.Infrastructure.Repositories.Abstract;
using ServiceCore.Models.Concrete;
using System.Formats.Asn1;
using System.Globalization;

namespace ReportService.Application.Services.Concrete
{
    public class ReportBusiness : IReportBusiness
    {
        IReportRepository _repository;
        private readonly IMapper _mapper;
        public ReportBusiness(IReportRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
     
        public async Task<Report> Add(CreateReportDto model)
        {

            var report = new Report()
            {
                Id = Guid.NewGuid(),
                Location = model.Location,
                RequestedAt = DateTime.Now.ToUniversalTime(),
                Status = Domain.Enums.ReportStatus.InProgress,
                TotalHotels = 0,
                TotalPhoneNumbers = 0
            };   
            await _repository.Create(report);

            await CreateReport(report);
            return report;
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<Report> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Report>> GetAll()
        {
            var result = await _repository.GetAll();
            return  result;
        }

        public Task<Report> Add(string data)
        {
            var reportDto = JsonConvert.DeserializeObject<CreateReportDto>(data);
            throw new NotImplementedException();
        }


        public async Task CreateReport(Report _report)
        {
            var hotelApi = $"http://localhost:7501/api/Hotel/GetReportDatasByLocation/{_report.Location}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(hotelApi);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<StatisticsHotelDto>>(json).FirstOrDefault(); 

                        WriteToTxt(data,_report.Id.ToString()); // gelen pathi database'e yaz
                        _report.Status = ReportStatus.Completed;
                        _report.TotalHotels = data.HotelCount;
                        _report.TotalPhoneNumbers = data.ConnectionCount;
                        await Update(_report);                        
                    }
                    else
                    {
                        Console.WriteLine("HTTP request failed with status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }  
        }
        private string  WriteToTxt(StatisticsHotelDto data, string reportId)
        {
            string fileName = $"report-{reportId}.txt"; // Dosya adı
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                if (data != null)
                {
                    writer.WriteLine($"Location: {data.Location}");
                    writer.WriteLine($"Hotel Count: {data.HotelCount}");
                    writer.WriteLine($"Connection Count: {data.ConnectionCount}");
                }
                else
                { 
                    writer.WriteLine("Data is null."); 
                }
            }
            Console.WriteLine("Report has been created");
            return filePath;
        }

        public async Task<Report> Update(Report model)
        { 
            await _repository.Update(model);
           
            return model;
        }
    }

}
