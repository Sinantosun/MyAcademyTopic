Merhaba,

Topic Blog projesinde bütün crud işlemlerini api tarafında gerçekleştirip uı tarafında ise api de oluşturuan crud işlemlerinin tüketilmesini sağladık.
Api tarafında Silme,Güncelleme Ekleme, Listleme, Id değerine göre getirme ve ayrıca proje içinde entitylere özgü methotlar da api ile consume edildi.

<h1>Topic Blog UI</h1>
<hr>
<h1>Otomatik Tamamlama / Arama </h1>

![image01](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/29e5e219-ec8b-4446-b018-40c2cd748a7b)

📌 Sitenin nasıl çalıştığı hakkında bilgi<br>
📌 görselde görülen texbox aracılığıyla aranacak bloglar jquery autoComplete ile api üzerinden entity özgü method yazılarak tüketilmiştir.<br>
📌 AutoComplete fonksiyonu içerisinde ajax ile texboxa girilen değer api tarafında bulunan entitye özgü method tarfından işlenip sonuç dönüyüyor.<br>

<hr>

![image](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/32d67ec0-1bde-49bc-b580-8bd10713262e)

📌 Texboxa girilen değer api tarfından işlenip sonuç dönüyor, eğer sonuç varsa yukarıda bulunan görselde ki gibi bir sayfa yapısı bızı karşılıyor.
📌 Eğer apiden gelen sonuç boş ise (kayıt yok ise) aşağıda bulunan sonuç ekrana yansıyor.

![image](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/1a79d578-e618-48c3-84c2-bb3ab685510d)


