using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DLL.Context;

public class UkraineContext : IdentityDbContext {
    public UkraineContext(DbContextOptions<UkraineContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Entertainment> Entertainments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<WorkTime> WorkTimes { get; set; }
    public DbSet<Monument> Monuments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        builder.Entity<User>(UserConfigure);
        builder.Entity<Entertainment>(EntertainmentConfigure);
        builder.Entity<Monument>(MonumentConfigure);

        builder.Entity<Region>().HasData(new List<Region> {
            new () {
                Id = 1,
                Name = "Kyiv",
                Identifier = "AA",
                Area = 28131,
                Formed = new DateTime(1932,2,27),
                Description = "The capital and largest city of Ukraine, one of the largest and oldest cities in Europe. Located in the middle reaches of the Dnieper, in the northern Dnieper region. Political, socio-economic, transport, educational, scientific, historical, cultural and spiritual center of Ukraine. In the system of administrative-territorial organization of Ukraine, Kyiv has a special status determined by the Constitution, and is not part of any region, although it is the administrative center of Kyiv region. Location of central authorities of Ukraine, foreign missions, headquarters of most enterprises and public associations operating in Ukraine."
            }, new () {
                Id = 2,
                Name = "Kherson",
                Identifier = "BT",
                Area = 28461,
                Formed = new DateTime(1944,3,30),
                Description = "City in the south of Ukraine, the administrative center of the Kherson region. Located on the right high bank of the Dnieper. The population as of January 1, 2022 is 279,131 people. An important economic center of southern Ukraine. Significant railway junction (on the line Mykolaiv-Snihurivka-Dzhankoy), sea trade port, river port. Kherson has a satellite city Oleshka. Since July 17, 2020 it is the administrative center of Kherson district."
            }, new () {
                Id = 3,
                Name = "Lviv",
                Identifier = "BC",
                Area = 21831.97f,
                Formed = new DateTime(1939,12,4),
                Description = "Is an administrative-territorial unit in western Ukraine . It is one of the three regions of the historical and cultural region of Galicia (Eastern Lesser Poland), part of the Carpathian Euroregion . One of the most developed areas of the state in economic, tourist, cultural and scientific areas. It was formed on November 27, 1939 [ 2] after the annexation of the eastern part of Poland by the Soviet Union under the Molotov-Ribbentrop Pact ."
                              + "The Lviv region consists of 7 districts: Lviv , Drohobych , Chervonohrad , Stryj , Sambir , Zolochiv , and Yavoriv districts . Lviv region borders with Volyn , Rivne , Ternopil , Ivano-Frankivsk and Zakarpattia regions, has access to the state border with the Republic of Poland ."
                              + "The north of the region belongs to the zone of mixed forests, in particular, Maly Polissya ;"
                              + " the middle part - to the forest-steppe , where the ridges of Roztocze , Hologir , Voronyak , Opillya and the extreme western part of the Podil Upland stand out . Further south are the Carpathian foothills and, in fact, the Carpathians . They are represented by the Beskids . The southern border of the region coincides with the Verkhovyna Watershed . The territory of the region is also the main European watershed of the Black and Baltic Seas."
                              + " The southern part of the Lviv-Volyn coal basin and the western parts of the Pre - Carpathian oil and gas region and the Pre - Carpathian sulfur - bearing basin are located in the Lviv region . The largest industrial centers are Chervonohrad , Lviv and Boryslav-Drohobych - Stebnytsia."
                              + " Truskavets , Morshyn and Skhidnytsia are balneological resorts of international importance. Architectural ensembles of Lviv and Zhovkva , castles and other attractions, which are rich in the region, the Carpathian Mountains give great prospects for tourism development of the region."
            }, new () {
                Id = 4,
                Name = "Chernivtsi",
                Identifier = "CE",
                Area =  8097,
                Formed = new DateTime(1940,8,7),
                Description = "Region in the south-western part of Ukraine. Formed on August 7, 1940 from the northern, mostly inhabited by Ukrainians, part of Bukovina and the neighboring part of Bessarabia (with Khotyn). It is located within the Carpathians, Precarpathians (Bukovynian Prykarpattia) and Pokutsko-Bessarabian Upland."
            }, new () {
                Id = 5,
                Name = "Poltava",
                Identifier = "BI",
                Area =  28748,
                Formed = new DateTime(1937,9,22),
                Description = "Administrative-territorial unit of Ukraine with the center in the city of Poltava. Formed on September 22, 1937. Located in the middle part of the Left Bank of Ukraine and, in part, on the Right Bank of Ukraine. Most of the region lies within the Dnieper lowland and Poltava plain."
            }, new () {
                Id = 6,
                Name = "Mykolaiv",
                Identifier = "BE",
                Area =  24598,
                Formed = new DateTime(1937,9,22),
                Description = "Region in Ukraine. Formed on September 22, 1937. Located in the south of the Black Sea lowlands in the lower reaches of the Southern Bug River. In the west it borders with Odessa, in the north with Kirovograd, in the east and northeast with Dnepropetrovsk and in the southeast with Kherson regions. In the south it is washed by the waters of the Black Sea. Area - 24.6 thousand km. The center of the region is the city of Mykolayiv."
            }, new () {
                Id = 7,
                Name = "Khmelnytsky",
                Identifier = "BX",
                Area =  20629,
                Formed = new DateTime(1937,9,22),
                Description = "Region in the west of Ukraine. It was founded on September 22, 1937 by a resolution of the CEC of the USSR with its center in the city of Kamianets-Podilskyi."
            }, new () {
                Id = 8,
                Name = "Ternopil",
                Identifier = "BO",
                Area =  13823,
                Formed = new DateTime(1939,12,4),
                Description = "Administrative-territorial unit of Ukraine with the center in the city of Ternopil. Located on the Podil Upland, the southern border of the region runs along the Dniester River, the eastern - on Zbruch. It occupies the eastern part of Galicia, part of southern Volhynia and part of Western Podillya."
            }, new () {
                Id = 9,
                Name = "Zhytomyr",
                Identifier = "AM",
                Area =  29832,
                Formed = new DateTime(1937,9,22),
                Description = "Region in the north of Ukraine, within the Polissya lowland, in the south within the Dnieper upland. It borders the Gomel region of Belarus in the north, Kyiv in the east, Vinnytsia in the south, and Khmelnytsky and Rivne regions of Ukraine in the west. The administrative center is Zhytomyr. Created on September 22, 1937 from the western districts of Kyiv region."
            }, new () {
                Id = 10,
                Name = "Ivano-Frankivsk",
                Identifier = "AT",
                Area = 13928,
                Formed = new DateTime(1939,11,27),
                Description = "Administrative-territorial unit in the west of Ukraine. It is one of the three regions of the historical and cultural region of Galicia."
            }, new () {
                Id = 11,
                Name = "Chernihiv",
                Identifier = "CB",
                Area =  31865,
                Formed = new DateTime(1932,10,15),
                Description = "Region in the north-eastern part of Ukraine. It borders on the west with Kyiv, on the north - with the Gomel region of the Republic of Belarus and the Bryansk region of the Russian Federation, on the east - with Sumy, on the south - with Poltava regions of Ukraine."
            }, new () {
                Id = 12,
                Name = "Volyn",
                Identifier = "AC",
                Area = 20143,
                Formed = new DateTime(1939,12,4),
                Description = "Region in the north-west of Ukraine within the Polissya lowland (over 3/4 of the territory) and Volyn upland. It is bordered on the west by the Lublin Voivodeship of the Republic of Poland, on the north by the Brest Region of the Republic of Belarus, on the east by the Rivne Region, and on the south by the Lviv Region of Ukraine. A total of 395 kilometers of the state border runs within the region."
            }, new () {
                Id = 13,
                Name = "Donetsk",
                Identifier = "AH",
                Area = 26517,
                Formed = new DateTime(1932,7,17),
                Description = "Administrative-territorial unit of Ukraine. It was formed within the modern boundaries on June 3, 1938, when the Voroshilovgrad region was separated from it"
            }, new () {
                Id = 14,
                Name = "Odesa",
                Identifier = "BH",
                Area = 33310,
                Formed = new DateTime(1932,12,27),
                Description = "The largest region of Ukraine, located in the southwest of the country. One of the most developed regions of the country in economic, tourist, cultural and scientific areas. In the north and east it borders (clockwise) with Vinnytsia, Kirovohrad and Mykolayiv regions, is washed by the Black Sea, in the south - with Romania, in the west - with Moldova. The region includes Snake Island."
            }, new () {
                Id = 15,
                Name = "Vinnytsia",
                Identifier = "AB",
                Area = 26513,
                Formed = new DateTime(1932,12,27),
                Description = "Vinnytsia region was formed on February 27, 1932, when the CEC of the USSR approved the resolution of the IV extraordinary session of the All-Ukrainian Central Executive Committee of February 9, 1932 on the establishment of five regions in Ukraine. As of November 2020, the population is 370.0 thousand people. The regional center is the city of Vinnytsia. Located on the right bank of the Dnieper within the Podolsk Upland."
            }, new () {
                Id = 16,
                Name = "Dnipropetrovsk",
                Identifier = "AE",
                Area = 31914,
                Formed = new DateTime(1932,12,27),
                Description = "Region in Ukraine. Located in the central-eastern part of the country."
            }, new () {
                Id = 17,
                Name = "Sumy",
                Identifier = "BM",
                Area = 23834,
                Formed = new DateTime(1939,1,10),
                Description = "Region in the north-eastern part of Ukraine; covers parts of the Middle Russian Uplands and the Dnieper Lowland."
            }, new () {
                Id = 18,
                Name = "Transcarpathian",
                Identifier = "AO",
                Area = 12777,
                Formed = new DateTime(1946,1,22),
                Description = "Region in the south-west of Ukraine within the western part of the Ukrainian Carpathians and the Transcarpathian lowlands. In the north it borders with Lviv, in the east with Ivano-Frankivsk regions of Ukraine. In the south with Romania, in the southwest with Hungary, in the west with Slovakia, in the northwest with Poland. Regional center - Uzhgorod."
            }, new () {
                Id = 19,
                Name = "Rivne",
                Identifier = "BK",
                Area = 20047,
                Formed = new DateTime(1939,10,27),
                Description = "Region in Ukraine. Located in the northwest of the country."
            }, new () {
                Id = 20,
                Name = "Kharkiv",
                Identifier = "AX",
                Area = 31415,
                Formed = new DateTime(1932,2,27),
                Description = "Region in Slobidska Ukraine within the Dnieper lowlands and the Middle Russian uplands."
            }, new () {
                Id = 21,
                Name = "Kirovohrad",
                Identifier = "BA",
                Area = 24588,
                Formed = new DateTime(1939,1,10),
                Description = "It is located between the Dnieper and Southern Bug rivers in the south of the Dnieper Upland. Almost the entire territory of the region (except for the village of Vlasivka) is located on the right bank of the Dnieper. It borders Cherkasy in the north, Poltava in the northeast, Dnipropetrovsk in the east and southeast, Mykolayiv and Odesa in the south, and Vinnytsia in the west. According to one version, the geographical center of Ukraine is located near Dobrovelychkivka."
            }, new () {
                Id = 22,
                Name = "Cherkasy",
                Identifier = "CA",
                Area = 20900,
                Formed = new DateTime(1954,1,7),
                Description = "Administrative-territorial unit of Ukraine of the first level, located in the central forest-steppe part of the country on both banks of the middle reaches of the Dnieper and the Southern Bug."
            }, new () {
                Id = 23,
                Name = "Zaporizhzhia",
                Identifier = "AP",
                Area = 27180,
                Formed = new DateTime(1939,1,10),
                Description = "Administrative unit in the south of Ukraine. Located in the southeast of Ukraine, it occupies mainly the left-bank part of the lower reaches of the Dnieper River. Regional center - the city of Zaporozhye."
            }, new () {
                Id = 24,
                Name = "Luhansk",
                Identifier = "BB",
                Area = 26684,
                Formed = new DateTime(1938,6,3),
                Description = "Administrative-territorial unit of Ukraine, located in the east of the country, mainly in the basin of the middle reaches of the Seversky Donets. It ranks sixth in population and tenth in area among the administrative-territorial units of the country. In the south-west and west it borders with Donetsk region, and in the north-west - with Kharkiv region."
            }, new () {
                Id = 25,
                Name = "Crimea",
                Identifier = "AK",
                Area = 27000,
                Formed = new DateTime(1869,9,30),
                Description = "The peninsula on the northern coast of the Black Sea, from the northeast is bordered by the Sea of ​​Azov. Located in the south of Ukraine and covers the Autonomous Republic of Crimea, Sevastopol and partly the south of the Kherson region (north of the Arabat arrow); most of the peninsula (Crimea and Sevastopol) from the end of February 2014 was captured and occupied by Russian regular military units, and later temporarily annexed by the Russian Federation."
            }
        });
    }

    private void UserConfigure(EntityTypeBuilder<User> builder) {
        builder.Property(x => x.NickName).HasMaxLength(16).IsRequired();
    }
    private void EntertainmentConfigure(EntityTypeBuilder<Entertainment> builder) {
        builder.HasMany(x => x.Reviews).WithOne(x => x.Entertainment);
    }
    private void MonumentConfigure(EntityTypeBuilder<Monument> builder) {
        builder.HasMany(x => x.Reviews).WithOne(x => x.Monument).OnDelete(DeleteBehavior.NoAction);
    }
}