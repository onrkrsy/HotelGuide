# HotelGuide

HotelGuide, oteller ve onlara ait iletişim bilgilerini kaydetmek ve belirli konumlar için özel raporlar oluşturmak için tasarlanmış bir projedir.


![mimari](https://github.com/onrkrsy/HotelGuide/assets/11960564/2723fea7-1501-485f-a267-86bf45dd87c7)

## Proje Yapısı

Bu proje, 1 Gateway ve 2 mikroservisten oluşmaktadır:

- **ApiGateway**: Gelen istekleri 7500 numaralı porttan karşılar ve HotelService ve ReportService'e yönlendirir. Eğer "api/CreateReport/{location}" isteği gelirse, bu isteği MassTransit-RabbitMQ aracılığıyla ReportService tarafından dinlenen bir kuyruğa iletir.

- **HotelService**: Otellerin ve onlara ait iletişim bilgilerinin tüm CRUD (Create, Read, Update, Delete) işlemlerinin gerçekleştirildiği mikroservistir.

- **ReportService**: ReportService, dinlediği kuyruktan bir rapor oluşturma isteği aldığında Reports tablosuna bir kayıt ekler ve durumu "InProgress" olarak işaretler. Ardından asenkron bir şekilde raporu oluşturma işlemini başlatır. HotelService'in "GetReportDatasByLocation/{location}" endpoint'ine HTTP isteği göndererek oluşturulacak rapor bilgilerini alır. Bu bilgileri raporun adıyla birlikte bir ".txt" dosyasına yazar. Son olarak, raporun durumunu "Completed" olarak günceller.

### Örnek İstek
![pmcol](https://github.com/onrkrsy/HotelGuide/assets/11960564/16cc407a-b278-4f53-853e-b0c0568d6752)


## Kurulum

- Message-Queueing için **RabbitMQ** ve veritabanı için **PostgreSQL** kurulumu gereklidir.
- **HotelService.Api** ve **ReportService.Api** projelerinin `appsettings.json` dosyalarında bağlantı dizesi (ConnectionString) ayarlarının yapılması gerekir.
- **ApiGateway** projesinin `appsettings.json` dosyasında RabbitMQ ayarlarının yapılması gereklidir.

## Yapılacaklar

- Middleware'ler ile loglama ve hata yönetimi (exception handling) mekanizması henüz kurulmamıştır. Bu nedenle ElasticSearch kullanılmamıştır.
- Servis metodlarının yanıtlarının SuccessResponse, ErrorResponse gibi ortak cevaplara dönüştürülmesi gerekmektedir.
- Testler henüz yazılmamıştır.
- Uygulamalar Dockerize edilmemiştir.

