namespace e_voting
{
    class notes
    {
        /*metrogrid5'in amacı şeydi eğer lstkod ve lstisimdeki isimler
 giderse orada kalsın diyeydi sonuçta program kapandığı zaman 
listboxtan gider ama datagridden gitmez, bu amaçla metrogrid5'i koymuştum*/
        /*eğer tek başına if olarak kalsaydı daha sonra alttan try catch komutuna yine devam edecektir
        ama şimdi else koyduğun için eğer veri yoksa durucak ve try içindeki işlemleri yapmaya girişmeyecek.
        eğer if şartı sağlamasaydı bu sefer direkt try yapısına inmiş olacaktı ama istemediğimiz şekilde yani veri
        girişi yapılmış mı yapılmamış mı bunun kontrolünü yapmadan ilerleyecekti*/
        /*int toplam = 0;
        int[] sayilar = new int[metroGrid7.Rows.Count];
        for (int i = 0; i < metroGrid7.Rows.Count; i++)
        {
            sayilar[i] = Convert.ToInt32(metroGrid7.Rows[i].Cells[1].Value.ToString());
            toplam += sayilar[i];

            int value = Convert.ToInt32(metroGrid7.Rows[i].Cells[1].Value.ToString());
            int yüzde = (value / toplam) * 100;
            metroGrid7.Rows[i].Cells[0].Value = metroGrid7.Rows[i].Cells[0].Value.ToString() + " (%" + yüzde + ")";

        doğru, satırın ismi değişiyor ya o yüzden yeni satır açtırtıyor
        }*/
        /*//microsoft office.14.object library, sonra nugetten microsoft office interop'u ekleyip yapacağız
         */
        //bunu da ayarlayalım lan, eğer iki kere excel tekrar okutulmaya çalışılırsa birden fazla oy gönderimi demektir bu, 
        //ama son gönderilen her zaman geçerli olacağı için istediği kadar 2 tane göndersin manasız olacaktır çünkü sadece son gönderilen geçerli olacaktır
        //ama bu durum ilk gönderilenlerin geçersiz olmasına yol açacak lan!!! o zaman access bosalt'ı kapatmak lazım ya da access taratması yapmak 
        //lazım(bu daha sağlıklı gibi, böylece istenmeyen kimseye birden fazla kod gönderilemeyecek)
        //şifre değiştirme olayını eklememiz lazım her iki kısma da ya, ya da belirtmek lazım şifre değişirse işler olmaz filan diye
        //buldum, oylama bitti ve veriler temizlendi olsun, bunun için access bosalt lazım son kısımda
        //OHA MÜKEMMEL KODMUŞ LAN BU; (metroGrid5.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '{0}%' OR Name LIKE '% {0}%'", TextBox1.Text);
        //metrogrid5'te arama yaptırıyoruz ya ondan dolayı sanki orada veriler silinmiş gibi gözüküyor ama değil arama sonucu boş çıktığı için orada kimse görünmüyor yoksa içindeki veriler hala duruyor yani
        //doğrulama kodu çok güzel kod valla, takdir ettim çok mantıklı ve tutarlı yazılmış bir kod gerçekten*/


        /*datasource larda ekleme silme işlemini her zaman datatable üstünden yürütmek gerekiyormuş demek, enteresan ya
orada aslında kodların çalışmama sebebini ben yanlış yorumladım alışkın olmadığım için çünkü o as datatable
komutu sayesinde metrogridde eleman var olmasına rağmen aramadan kaynaklı olarak hafızada kalıyor ve görmüyor
listboxları devreye sokunca anca düzeldi sonra kod*/


        //bu satır önemli bak dursun, demek datasource olanlara ekleme silme işlemlerini böyle yapıyormuşuz
        /*for (int i = 0; i < length; i++)
        {
            metroGrid4.Rows.RemoveAt(i);
            metroGrid4.Refresh();
        }*/

        //treli name'i olan sütunlarda arama yaptırmadı nedense

        /*string[] mailkontrol = mail.Distinct().ToArray();
        string[] isimkontrol = isim.Distinct().ToArray();
        ulan distinctlerde böyle bir sorun yaşayacağım hiç aklıma gelmezdi lan ama aslında çok mantıklı bir hata lan
        aynı isimler ama farklı ve geçerli mail adresleri olduğu için adresler düzgünce ekleniyor ama isimler eksik kalıyor sonra
        sonra program hata vermeden çökmüş gibi oluyor
        tüm distinctleri kontrol et bi bakalım böyle bir sorun olma potansiyeli var mı acaba
        demek verileri o zaman tablelarla çözecek yine işte aynısı var mı yok mu şeklinde ve isimleri öyle ekleteceğiz, daha sağlıklı oluyor
        distinct güzel metot aslında ama daha bugsuz bir yol buldum sanırsam bu tablelar ile*/


        //evet, mail adreslerini boşluksuz aldırmak lazım metrogrid1'e, çok fark ettiriyor o; ben öyle almıyormuydum bunları aslında ya


        //tam tahmin ettiğim gibi, dv bir excel kaynağı olduğu için kaynağın sütunu belirli bir şey değil
        //sen buna bir kere sütun tanıttıktan sonra hep onu sütunu olarak tanıyor ve diğer sütunlar eklenmeye çalışıldığı zaman basıyor hatayı
        //üsttekinde neden bu durum yaşanmamış ki acaba enteresan, ondada mı yoksa sütunu filan sildim ya da o grid'in sütun değerleri belli ve sabit miydi
        //sanki sabit sütun değerleri vardı gibi geliyor bana sanırsam ondan dolayı bir sorun yaşanmadı üstte ama bunda sabit sütun değeri olmayınca böyle bir sıkıntı
        //yaşandı işte, yaşanacağı varmış demek yaşandı ve bitti :D
        //hakkaten böyleymiş lan, sabit sütun değeri ayırabilmek önemli bir şeymiş demek yoksa sonra bu şekilde sıkıntılar yaşayabiliyorsun
        //bu yüzden ya sabit sütun değerleri kullanacaksın ya da sütunları her seferinde silip yeniden yükleyeceksin
        //artık hangisi işine gelirse daha çok ona göre kullanırsın, bu bilgiyi öğrendiğim iyi oldu


        //belki unclickable yapamam seni ama unclickable olamadığına pişman edecek, onun o özelliğini fark türlerde deşfire edecek 
        //bir şeyler yazabilirim sevgili cell'ciğim :))
        //seni arkaplanda işaretlenmiş olarak işaretlerim ve böylece sana istendiği kadar "fiziksel" olarak tıklansın, 
        //"zihinsel" olarak sana hiç bir şey tıklanamayacak hale getiririm :))


        //buldum, eğer yeni satırlar ekletirsek alta ------ lı yerlerin ardından, yüzdeli oy sonuçlarına yer veririz, ama ne derece gerekli olur ki bu?
        /*oha, boşluğa tıkladın mı en üsttekine oy gidiyor, çünkü null ya onlar satır "0" sayılıyor ve üstteki oyu açıyor, 
        yapacak bir şey yok buna en azından her satıra br kere tıklatmayı kontrol edebildiğim için sorun olmuyor*/
        /*ulan program haklı tabi amq, to string ile bitirdiğin değere nasıl aktarma yapacaksın, 
         zaten tostring diyerek değer bu demişsin sen, onun üstüne daha nasıl bir oynama yapmayı planlıyorsun acaba sevgili tahir?*/
    }
}
