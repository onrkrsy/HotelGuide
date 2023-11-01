# HotelGuide

HotelGuide, oteller ve onlara ait ileti�im bilgilerini kaydetmek ve belirli konumlar i�in �zel raporlar olu�turmak i�in tasarlanm�� bir projedir.

![Proje Mimarisi](resim-baglantisi)

## Proje Yap�s�

Bu proje, 1 Gateway ve 2 mikro hizmetten olu�maktad�r:

- **ApiGateway**: Gelen istekleri 7500 numaral� porttan kar��lar ve HotelService ve ReportService'e y�nlendirir. E�er "api/CreateReport/{location}" iste�i gelirse, bu iste�i MassTransit-RabbitMQ arac�l���yla ReportService taraf�ndan dinlenen bir kuyru�a iletir.

- **HotelService**: Otellerin ve onlara ait ileti�im bilgilerinin t�m CRUD (Create, Read, Update, Delete) i�lemlerinin ger�ekle�tirildi�i mikro hizmettir.

- **ReportService**: ReportService, dinledi�i kuyruktan bir rapor olu�turma iste�i ald���nda Reports tablosuna bir kay�t ekler ve durumu "InProgress" olarak i�aretler. Ard�ndan asenkron bir �ekilde raporu olu�turma i�lemini ba�lat�r. HotelService'in "GetReportDatasByLocation/{location}" endpoint'ine HTTP iste�i g�ndererek olu�turulacak rapor bilgilerini al�r. Bu bilgileri raporun ad�yla birlikte bir ".txt" dosyas�na yazar. Son olarak, raporun durumunu "Completed" olarak g�nceller.

## Kurulum

- Message-Queueing i�in **RabbitMQ** ve veritaban� i�in **PostgreSQL** kurulumu gereklidir.
- **HotelService.Api** ve **ReportService.Api** projelerinin `appsettings.json` dosyalar�nda ba�lant� dizesi (ConnectionString) ayarlar�n�n yap�lmas� gerekir.
- **ApiGateway** projesinin `appsettings.json` dosyas�nda RabbitMQ ayarlar�n�n yap�lmas� gereklidir.

## Eksikler

- Middleware'ler ile loglama ve hata y�netimi (exception handling) mekanizmas� hen�z kurulmam��t�r. Bu nedenle ElasticSearch kullan�lmam��t�r.
- Servis metodlar�n�n yan�tlar�n�n SuccessResponse, ErrorResponse gibi ortak cevaplara d�n��t�r�lmesi gerekmektedir.
- Testler hen�z yaz�lmam��t�r.
- Uygulamalar Dockerize edilmemi�tir.

Bu projeyi geli�tirmeye devam etmek ve eksiklikleri gidermek istiyorsan�z, a�a��daki d�zenlemeleri yapabilirsiniz.
