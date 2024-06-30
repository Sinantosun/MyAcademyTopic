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

📌 Texboxa girilen değer api tarfından işlenip sonuç dönüyor, eğer sonuç varsa yukarıda bulunan görselde ki gibi bir sayfa yapısı bızı karşılıyor.<br>
📌 Eğer apiden gelen sonuç boş ise (kayıt yok ise) aşağıda bulunan sonuç ekrana yansıyor.<br>

![image](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/1a79d578-e618-48c3-84c2-bb3ab685510d)

<hr>

<h1>Ana Sayfada kategorilerin listesi</h1>

![image02](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/df048f80-2bae-43c2-b816-cecd89d85d1c)

📌 Burada kategorilerin listesi yer almaktadır ayrıca bu kısımda ilgili kategorinin kaç tane bloğa sahip olduğu bilgisi de bulunmaktadır.

<h1>Sıkça Sorulan Sorular Alanı</h1>

![image03](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/516a508f-8cee-4a16-a8ee-8a34a0cf9de9)

📌 Eklenen sıkça sorulan soruların başlığı ve ilgili başlığın açılklaması akardiyon menü şeklinde apiden tüketiliyor.

<h1>Blogların Listesi</h1>

![image04](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/0fd6fc97-66e1-40c6-899f-3b1169723798)

📌 Burada yayınlanan bütün bloglar yer almaktadır. <br>
📌 api isteğini X.PagedList şekline dönüştürüp her sayfa için 5 bloğun gelmesi sağlanmıştır. <br>

<h1>Kategorilerin Listesi</h1>

![image05](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/11e0e4b5-482a-4f88-8203-d1ac0222b48b)

📌 Burada yayınlanan bütün kategoriler yer almaktadır. <br>
📌 daha fazlası butonu aracığıyla bu kategoriye ait bloglar listelenmektedir.

<h1>Bloğa ait detay sayfası</h1>

![image06](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/6f32bdc2-8d7f-44f7-a924-e5032e0bdabb)

📌 Burada ilgili bloğun detayları görünür. <br>
📌 Bloglar eklenirken summerNote Textarea kullanımıştır ve bu sayfa içinde apiden gelen uzun açıklama propertysi html raw edilerek blog kayıt edilirken eklenen html kodlarının (yazıların kalın yazılması numaralandırma yazıların altını çizme vb alanların) çalışması sağlanır.

<h1>Admin Dashboard Alanı</h1>

![image08](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/0a99dd93-8049-418e-a84f-2ddde1e012de)

📌Bu alanda entiye özgü methodlar api tarafından tüketilmiştir (blogların sayıları bütün kategorilerin sayıları ve sadece aktif olan kategorilerin sayıları) <br>
📌 Tablo halinde kategorilerin kaç tane bloğa sahip olduğu admin tarafına gösteriliyor.

<h1>Admin Tarafi Blogların Listesi</h1>

![image07](https://github.com/Sinantosun/MyAcademyTopic/assets/145317724/a2e65efc-e9e4-45ff-bf4b-2c3412cad240)

📌 Admin burada api üzerinde istekte bulunarak silme güncelleme ve listeleme ve ekleme işlemlerini yapabilir.





