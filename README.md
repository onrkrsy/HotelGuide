# HotelGuide

HotelGuide, oteller ve onlara ait iletiþim bilgilerini kaydetmek ve belirli konumlar için özel raporlar oluþturmak için tasarlanmýþ bir projedir.

![Proje Mimarisi](resim-baglantisi)

## Proje Yapýsý

Bu proje, 1 Gateway ve 2 mikro hizmetten oluþmaktadýr:

- **ApiGateway**: Gelen istekleri 7500 numaralý porttan karþýlar ve HotelService ve ReportService'e yönlendirir. Eðer "api/CreateReport/{location}" isteði gelirse, bu isteði MassTransit-RabbitMQ aracýlýðýyla ReportService tarafýndan dinlenen bir kuyruða iletir.

- **HotelService**: Otellerin ve onlara ait iletiþim bilgilerinin tüm CRUD (Create, Read, Update, Delete) iþlemlerinin gerçekleþtirildiði mikro hizmettir.

- **ReportService**: ReportService, dinlediði kuyruktan bir rapor oluþturma isteði aldýðýnda Reports tablosuna bir kayýt ekler ve durumu "InProgress" olarak iþaretler. Ardýndan asenkron bir þekilde raporu oluþturma iþlemini baþlatýr. HotelService'in "GetReportDatasByLocation/{location}" endpoint'ine HTTP isteði göndererek oluþturulacak rapor bilgilerini alýr. Bu bilgileri raporun adýyla birlikte bir ".txt" dosyasýna yazar. Son olarak, raporun durumunu "Completed" olarak günceller.

## Kurulum

- Message-Queueing için **RabbitMQ** ve veritabaný için **PostgreSQL** kurulumu gereklidir.
- **HotelService.Api** ve **ReportService.Api** projelerinin `appsettings.json` dosyalarýnda baðlantý dizesi (ConnectionString) ayarlarýnýn yapýlmasý gerekir.
- **ApiGateway** projesinin `appsettings.json` dosyasýnda RabbitMQ ayarlarýnýn yapýlmasý gereklidir.

## Eksikler

- Middleware'ler ile loglama ve hata yönetimi (exception handling) mekanizmasý henüz kurulmamýþtýr. Bu nedenle ElasticSearch kullanýlmamýþtýr.
- Servis metodlarýnýn yanýtlarýnýn SuccessResponse, ErrorResponse gibi ortak cevaplara dönüþtürülmesi gerekmektedir.
- Testler henüz yazýlmamýþtýr.
- Uygulamalar Dockerize edilmemiþtir.

Bu projeyi geliþtirmeye devam etmek ve eksiklikleri gidermek istiyorsanýz, aþaðýdaki düzenlemeleri yapabilirsiniz.
