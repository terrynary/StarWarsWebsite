using StarWarsApiCSharp;
using StarWarsWebsite.Server.Models;

namespace StarWarsWebsite.Server.Context
{
    public class DataSeeding
    {
        public static void Initialize(StarWarsContext context)
        {
            context.Database.EnsureCreated();

            if (!context.StarShips.Any())
            {
                IRepository<StarShip> starshipRepo = new Repository<StarShip>();
                var starships = starshipRepo.GetEntities(size: int.MaxValue);
                foreach (var starship in starships)
                {
                    switch (starship.Name)
                    {
                        case "CR90 corvette":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/6/66/CR90corvette-BTMF18.png/revision/latest?cb=20240908033909";
                            break;
                        case "Star Destroyer":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/f/f9/ExecutorEscort-BTMF27.png/revision/latest?cb=20240908214123";
                            break;
                        case "Sentinel-class landing craft":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/5/5b/Imperial_Sentinel-class_shuttle.png/revision/latest?cb=20161008235432";
                            break;
                        case "Death Star":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/7/70/DSI-HDapproach.png/revision/latest?cb=20130221005853";
                            break;
                        case "Millennium Falcon":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/5/52/Millennium_Falcon_Fathead_TROS.png/revision/latest?cb=20221029015218";
                            break;
                        case "Y-wing":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/8/81/Y-wing.png/revision/latest?cb=20161110013308";
                            break;
                        case "X-wing":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/0/00/Xwing-ROOCE.png/revision/latest?cb=20230516042654";
                            break;
                        case "TIE Advanced x1":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/1/1d/Vader_TIEAdvanced_SWB.png/revision/latest?cb=20160915042032";
                            break;
                        case "Executor":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/3/30/Executor_BF2.png/revision/latest?cb=20230405071103";
                            break;
                        case "Rebel transport":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/4/44/GR-75MediumTransport-100Scenes.png/revision/latest?cb=20221105213502";
                            break;
                        case "Slave 1":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/b/ba/Slave_I_DICE.png/revision/latest?cb=20230723041624";
                            break;
                        case "Imperial shuttle":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/a/a9/Imperial_shuttle.png/revision/latest?cb=20150827042115";
                            break;
                        case "EF76 Nebulon-B escort frigate":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/7/71/NebulonB-SWS.png/revision/latest?cb=20210303023412";
                            break;
                        case "Calamari Cruiser":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/1/11/MC30cbarrage.jpg/revision/latest?cb=20070114122903";
                            break;
                        case "A-wing":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/e/ec/Resistance_A-wing_SWCT.png/revision/latest?cb=20181015045043";
                            break;
                        case "B-wing":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/9/9f/B-wing-Squadronds.png/revision/latest?cb=20210722003428";
                            break;
                        case "Republic Cruiser":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/9/9c/Venator2-SWE.png/revision/latest?cb=20231002235917";
                            break;
                        case "Droid control ship":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/b/bc/CISLucrehulkBattleship-TCW.png/revision/latest?cb=20231010233338";
                            break;
                        case "Naboo fighter":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/6/64/N-1_Starfighter.png/revision/latest?cb=20240909024317";
                            break;
                        case "Naboo Royal Starship":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/9/9e/Naboo_Royal_Starship.png/revision/latest?cb=20161019065403";
                            break;
                        case "Scimitar":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/1/1c/Scimitar-USC.png/revision/latest?cb=20190604143506";
                            break;
                        case "J-type diplomatic barge":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/2/2b/Royalcruiser.jpg/revision/latest?cb=20091201140703";
                            break;
                        case "AA-9 Coruscant freighter":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/c/c7/Aa9coruscantfreighter.jpg/revision/latest?cb=20091201131352";
                            break;
                        case "Jedi starfighter":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/7/7a/Jsf_duo2.jpg/revision/latest?cb=20060706121723";
                            break;
                        case "H-type Nubian yacht":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/8/87/H-Type_Nubian_yacht_USW.png/revision/latest/scale-to-width-down/1000?cb=20241019020944";
                            break;
                        case "Republic Assault ship":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/7/70/Acclamator-TCWIV.png/revision/latest?cb=20221105061503";
                            break;
                        case "Solar Sailer":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/1/10/CountDookusSolarSailer-WotF.png/revision/latest?cb=20200518063614";
                            break;
                        case "Trade Federation cruiser":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/4/47/InvisibleHandStarboard-FF.png/revision/latest?cb=20221119215500";
                            break;
                        case "Theta-class T-2c shuttle":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/8/8e/Theta-class_shuttle.png/revision/latest?cb=20220304110027";
                            break;
                        case "Republic attack cruiser":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/c/c8/Imperialattackcruisers.png/revision/latest?cb=20140317112248";
                            break;
                        case "Naboo star skiff":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/d/df/Naboo_star_skiff_1.png/revision/latest?cb=20130212042348";
                            break;
                        case "Jedi Interceptor":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/0/04/Eta-2JediInterceptor-USC.png/revision/latest?cb=20231105182911";
                            break;
                        case "arc-170":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/9/99/ARC170-SWE.png/revision/latest?cb=20230710001455";
                            break;
                        case "Banking clan frigte":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/a/a7/CISMunificent-TCW.png/revision/latest?cb=20231010233644";
                            break;
                        case "Belbullab-22 starfighter":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/2/21/SoullessOne-TCW.png/revision/latest?cb=20221117145011";
                            break;
                        case "V-wing":
                            starship.ImgUrl = "http://static.wikia.nocookie.net/starwars/images/6/66/Nimbus-class_V-wing_TFOWM.png/revision/latest?cb=20190629212809";
                            break;
                        default:
                                starship.ImgUrl = "";
                                break;
                    }
                }
                context.StarShips.AddRange(starships);
            }
            context.SaveChanges();
        }
    }
}
