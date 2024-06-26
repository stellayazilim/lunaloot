﻿using LunaLoot.Master.Domain.Aggregates.AddressAggregate.ValueObjects;

// ReSharper disable StringLiteralTypo

namespace LunaLoot.Master.Infrastructure.Services;


public class CountryListProvider
{
   public IEnumerable<Country> Countries = new List<Country>()
   {
      Country.CreateNew("Afghanistan", "AF", "004"),
      Country.CreateNew("Albania", "AL", "008"),
      Country.CreateNew("Algeria", "DZ", "012"),
      Country.CreateNew("American Somoa", "016"),
      Country.CreateNew("Andora", "AD", "020"),
      Country.CreateNew("Angola", "AO", "024"),
      Country.CreateNew("Anguilla", "AI", "660"),
      Country.CreateNew("Antartica", "AQ", "010"),
      Country.CreateNew("Antiqua and Barbuda", "AG", "028"),
      Country.CreateNew("Argentina", "AR", "032"),
      Country.CreateNew("Armenia", "AM", "051"),
      Country.CreateNew("Aruba", "AW", "533"),
      Country.CreateNew("Australia", "AU", "036"),
      Country.CreateNew("Austria", "AT", "040"),
      Country.CreateNew("Azerbaijan", "AZ", "031"),
      Country.CreateNew("Bahamas (the)", "BS", "044"),
      Country.CreateNew("Bahrain", "BH", "048"),
      Country.CreateNew("Bangladesh", "BD", "050"),
      Country.CreateNew("Barbados", "BB", "052"),
      Country.CreateNew("Belarus", "BY", "112"),
      Country.CreateNew("Belgium", "BE", "056"),
      Country.CreateNew("Belize", "BZ", "084"),
      Country.CreateNew("Benin", "BJ", "204"),
      Country.CreateNew("Bermuda", "BM", "060"),
      Country.CreateNew("Åland Islands", "AX", "248"),
      Country.CreateNew("Bhutan", "BT", "064"),
      Country.CreateNew("Bolivia (Plurination State of)", "BO", "064"),
      Country.CreateNew("Bonaire, Sint Eustatius and Saba", "BQ", "535"),
      Country.CreateNew("Bosnia and Herzegovina", "BA", "070"),
      Country.CreateNew("Botswana", "BW", "072"),
      Country.CreateNew("Bouvet Island", "BV", "074"),
      Country.CreateNew("Brazil", "BR", "076"),
      Country.CreateNew("British Indian Ocean Territory (the)", "IO", "086"),
      Country.CreateNew("Brunei Darussalam", "BN", "096"),
      Country.CreateNew("Bulgaria", "BG", "100"),
      Country.CreateNew("Burkina Faso", "BF", "854"),
      Country.CreateNew("Burundi", "BI", "108"),
      Country.CreateNew("Cabo Verde", "CV", "132"),
      Country.CreateNew("Cambodia", "KH", "116"),
      Country.CreateNew("Cameroon", "CM", "120"),
      Country.CreateNew("Canada", "CA", "124"),
      Country.CreateNew("Cayman Islands (the)", "KY", "140"),
      Country.CreateNew("Central African Republic", "CF", "140"),
      Country.CreateNew("Chad", "TD", "148"),
      Country.CreateNew("Chile", "CL", "152"),
      Country.CreateNew("China", "CN", "156"),
      Country.CreateNew("Christmas Island", "CX", "162"),
      Country.CreateNew("Cocos (Keeling) Islands (the)", "CC", "166"),
      Country.CreateNew("Colombia", "CO", "170"),
      Country.CreateNew("Comoros (the)", "KM", "174"),
      Country.CreateNew("Congo (the Democratic Republic of the", "CD", "180"),
      Country.CreateNew("Congo (the)", "CG", "178"),
      Country.CreateNew("Cook Islands (the)", "CK", "184"),
      Country.CreateNew("Costa Rica", "CR", "188"),
      Country.CreateNew("Crotia", "HR", "191"),
      Country.CreateNew("Cuba", "CU", "192"),
      Country.CreateNew("Curaçao", "CW", "531"),
      Country.CreateNew("Cyprus", "CY", "196"),
      Country.CreateNew("Czechia", "CZ", "203"),
      Country.CreateNew("Côte d'Ivoire", "CI", "384"),
      Country.CreateNew("Denmark", "DK", "208"),
      Country.CreateNew("Djibouti", "Dj", "262"),
      Country.CreateNew("Dominica", "DM", "212"),
      Country.CreateNew("Dominician Republic (the)", "DO", "214"),
      Country.CreateNew("Ecuador", "EC", "218"),
      Country.CreateNew("Egypt", "EG", "818"),
      Country.CreateNew("El Salvador", "SV", "222"),
      Country.CreateNew("Equatorial Guinea", "GQ", "226"),
      Country.CreateNew("Eritrea", "ER", "232"),
      Country.CreateNew("Estonia", "EE", "233"),
      Country.CreateNew("Eswatini", "SZ", "748"),
      Country.CreateNew("Ethiopia", "ET", "231"),
      Country.CreateNew("Falkland Islands (the) [Malvinas]", "FO", "234"),
      Country.CreateNew("Faroe Islands (the)", "FO", "234"),
      Country.CreateNew("Fiji", "Fj", "242"),
      Country.CreateNew("Finland", "FI", "246"),
      Country.CreateNew("France", "FR", "250"),
      Country.CreateNew("French Guiana", "GF", "254"),
      Country.CreateNew("French Polynesia", "PF", "258"),
      Country.CreateNew("French Southern Territories (the)", "TF", "260"),
      Country.CreateNew("Gabon", "GA", "266"),
      Country.CreateNew("Gambia (the)", "GM", "270"),
      Country.CreateNew("Georgia", "GE", "258"),
      Country.CreateNew("Germany", "DE", "276"),
      Country.CreateNew("Ghana", "GH", "288"),
      Country.CreateNew("Gibraltar", "GI", "292"),
      Country.CreateNew("Greece", "GR", "300"),
      Country.CreateNew("Greenland", "GL", "304"),
      Country.CreateNew("Grenada", "GD", "308"),
      Country.CreateNew("Guadeloupe", "GP", "312"),
      Country.CreateNew("Guam", "GU", "316"),
      Country.CreateNew("Guatemala", "GT", "320"),
      Country.CreateNew("Guernsey", "GG", "831"),
      Country.CreateNew("Guinea", "GN", "324"),
      Country.CreateNew("Guinea-Bissau", "GW", "624"),
      Country.CreateNew("Guyana", "GY", "328"),
      Country.CreateNew("Haiti", "HT", "332"),
      Country.CreateNew("Heard Island and McDonald Islands", "HM", "334"),
      Country.CreateNew("Holy See (the)", "VA", "336"),
      Country.CreateNew("Honduras", "HN", "340"),
      Country.CreateNew("Hong Kong", "HK", "344"),
      Country.CreateNew("Hungary", "HU", "348"),
      Country.CreateNew("Iceland", "IS", "352"),
      Country.CreateNew("India", "IN", "356"),
      Country.CreateNew("Indonesia", "ID", "360"),
      Country.CreateNew("Iran (Islamic Republic Of)", "IR", "364"),
      Country.CreateNew("Iraq", "IQ", "368"),
      Country.CreateNew("Ireland", "IE", "372"),
      Country.CreateNew("Isle of Man", "IM", "833"),
      Country.CreateNew("Israel", "IL", "376"),
      Country.CreateNew("Italy", "IT", "380"),
      Country.CreateNew("Jamaica", "JM", "388"),
      Country.CreateNew("Japan", "JP", "392"),
      Country.CreateNew("Jersey", "JE", "832"),
      Country.CreateNew("Jordan", "JO", "400"),
      Country.CreateNew("Kazakhstan", "KZ", "398"),
      Country.CreateNew("Kenya", "KE", "404"),
      Country.CreateNew("Kiribati", "KI", "296"),
      Country.CreateNew("Korea (the Democratic People's Republic of", "KP", "408"),
      Country.CreateNew("Korea (the Republic of)", "KR", "410"),
      Country.CreateNew("Kuwait", "KW", "414"),
      Country.CreateNew("Kyrgyzstan", "KG", "417"),
      Country.CreateNew("Lao People's Democratic Republic (the)", "LA", "418"),
      Country.CreateNew("Latvia", "LV", "428"),
      Country.CreateNew("Lebanon", "LB", "422"),
      Country.CreateNew("Lesotho", "LS", "426"),
      Country.CreateNew("Liberia", "LR", "430"),
      Country.CreateNew("Libya", "LY", "434"),
      Country.CreateNew("Liechtenstein", "LI", "438"),
      Country.CreateNew("Lithuania", "LT", "440"),
      Country.CreateNew("Luxembourg", "LU", "442"),
      Country.CreateNew("Macao", "MO", "446"),
      Country.CreateNew("Madagascar", "MG", "450"),
      Country.CreateNew("Malawi", "MW", "454"),
      Country.CreateNew("Malaysia", "MY", "458"),
      Country.CreateNew("Maldives", "MV", "462"),
      Country.CreateNew("Mali", "ML", "466"),
      Country.CreateNew("Malta", "MT", "470"),
      Country.CreateNew("Marshall Islands (the)", "MH", "584"),
      Country.CreateNew("Martinique", "MQ", "474"),
      Country.CreateNew("Mauritania", "MR", "478"),
      Country.CreateNew("Mauritius", "MU", "480"),
      Country.CreateNew("Mayotte", "YT", "175"),
      Country.CreateNew("Mexico", "MX", "484"),
      Country.CreateNew("Micronesia (Federated State of)", "FM", "583"),
      Country.CreateNew("Moldova (the Republic of)", "MD", "498"),
      Country.CreateNew("Monaco", "MC", "492"),
      Country.CreateNew("Mongolia", "MN", "496"),
      Country.CreateNew("Montenegro", "ME", "499"),
      Country.CreateNew("Montserrat", "MS", "500"),
      Country.CreateNew("Morocco", "MA", "504"),
      Country.CreateNew("Mozambique", "MZ", "508"),
      Country.CreateNew("Myanmar", "MM", "103"),
      Country.CreateNew("Namibia", "NA", "516"),
      Country.CreateNew("Nauru", "NR", "520"),
      Country.CreateNew("Nepal", "NP", "524"),
      Country.CreateNew("Netherlands (Kingdom of the)", "NL", "528"),
      Country.CreateNew("New Caledonia", "NC", "540"),
      Country.CreateNew("New Zealand", "NZ", "554"),
      Country.CreateNew("Nicaragua", "NI", "558"),
      Country.CreateNew("Niger (the)", "NE", "562"),
      Country.CreateNew("Niue", "NU", "570"),
      Country.CreateNew("Norfolk Island", "NF", "574"),
      Country.CreateNew("North Macedonia", "MK", "807"),
      Country.CreateNew("Northern Mariana Islands (the)", "MP", "580"),
      Country.CreateNew("Norway", "NO", "578"),
      Country.CreateNew("Oman", "OM", "512"),
      Country.CreateNew("Pakistan", "PK", "586"),
      Country.CreateNew("Palau", "PW", "585"),
      Country.CreateNew("Pelestine, State of", "PS", "275"),
      Country.CreateNew("Panama", "PA", "591"),
      Country.CreateNew("Papue New Guinea", "PG", "598"),
      Country.CreateNew("Paraguay", "PY", "600"),
      Country.CreateNew("Peru", "PE", "604"),
      Country.CreateNew("Philippines (the)", "PH", "608"),
      Country.CreateNew("Pitcaim", "PN", "612"),
      Country.CreateNew("Poland", "PL", "616"),
      Country.CreateNew("Portugal", "PT", "620"),
      Country.CreateNew("Puerto Rico", "PR", "630"),
      Country.CreateNew("Qatar", "QA", "634"),
      Country.CreateNew("Romania", "RO", "642"),
      Country.CreateNew("Russian Fedaration (the)", "RU", "643"),
      Country.CreateNew("Rwanda", "RW", "646"),
      Country.CreateNew("Réunion", "RE", "638"),
      Country.CreateNew("Saint Barthélemy", "BL", "652"),
      Country.CreateNew("Saint Helena, Ascension and Tristan da Cunha", "SH", "654"),
      Country.CreateNew("Saint Kitts and Nevis", "KN", "659"),
      Country.CreateNew("Saint Lucia", "LC", "662"),
      Country.CreateNew("Saint Martin (French Part)", "MF", "663"),
      Country.CreateNew("Saint Pierre and Miquelon", "PM", "666"),
      Country.CreateNew("Saint Vincent and the Grenadines", "VC", "670"),
      Country.CreateNew("Samoa", "WS", "882"),
      Country.CreateNew("San marino", "SM", "674"),
      Country.CreateNew("Sao Tome and Principe", "ST", "678"),
      Country.CreateNew("Saudi Arabia", "SA", "682"),
      Country.CreateNew("Senegal", "SN", "685"),
      Country.CreateNew("Serbia", "RS", "688"),
      Country.CreateNew("Seychelles", "SC", "690"),
      Country.CreateNew("Sierra Leone", "SL", "694"),
      Country.CreateNew("Singapore", "SG", "702"),
      Country.CreateNew("Sint Maarten (Dutch part)", "SX", "534"),
      Country.CreateNew("Slovakia", "SK", "703"),
      Country.CreateNew("Slovenia", "SI", "705"),
      Country.CreateNew("Solomon Islands", "SB", "090"),
      Country.CreateNew("Somalia", "SO", "706"),
      Country.CreateNew("South Africa", "ZA", "710"),
      Country.CreateNew("South Georgia and the South Sandwich Islands", "GS", "239"),
      Country.CreateNew("South Sudan", "SS", "728"),
      Country.CreateNew("Spain", "ES", "724"),
      Country.CreateNew("Sri Lanka", "LK", "144"),
      Country.CreateNew("Sudan (the)", "SD", "729"),
      Country.CreateNew("Suriname", "SR", "740"),
      Country.CreateNew("Svalbard and Jan Mayen", "SJ", "744"),
      Country.CreateNew("Sweden", "SE", "752"),
      Country.CreateNew("Switzerland", "CH", "756"),
      Country.CreateNew("Syrian Arab Republic (the)", "SY", "760"),
      Country.CreateNew("Taiwan (Province of China)", "TW", "158"),
      Country.CreateNew("Tajikistan", "TJ", "762"),
      Country.CreateNew("Tanzania, the United Republic of", "TZ", "834"),
      Country.CreateNew("Thailand", "TH", "764"),
      Country.CreateNew("Timor-Leste", "TL", "626"),
      Country.CreateNew("Togo", "TG", "768"),
      Country.CreateNew("Tokelau", "TK", "772"),
      Country.CreateNew("Tonga", "TO", "776"),
      Country.CreateNew("Trinidad and Tobago", "TT", "780"),
      Country.CreateNew("Tunisia", "TN", "788"),
      Country.CreateNew("Turkmenistan", "TM", "795"),
      Country.CreateNew("Turks and Caicos Islands (the)", "TC", "796"),
      Country.CreateNew("Tuvalu", "TV", "798"),
      Country.CreateNew("Türkiye", "TR", "792"),
      Country.CreateNew("Uganda", "UG", "800"),
      Country.CreateNew("Ukraine", "UA", "804"),
      Country.CreateNew("United Arab Emirates (the)", "AE", "784"),
      Country.CreateNew("United Kingdom of Great Britain and Northern Ireland (the)", "GB", "826"),
      Country.CreateNew("United States Minor Outlying Islands (the)", "UM", "581"),
      Country.CreateNew("United States of America (the)", "US", "840"),
      Country.CreateNew("Uruguay", "UY", "858"),
      Country.CreateNew("Uzbekistan", "UZ", "860"),
      Country.CreateNew("Vanuatu", "VU", "548"),
      Country.CreateNew("Venezuella (Bolivarian Republic of)", "VE", "862"),
      Country.CreateNew("Viet Nam", "VN", "704"),
      Country.CreateNew("Virgin Islands (British)", "VG", "092"),
      Country.CreateNew("Virgin Islands (U.S.)", "VI", "850"),
      Country.CreateNew("Wallis and Futuna", "WF", "876"),
      Country.CreateNew("Western Sahara", "EH", "732"),
      Country.CreateNew("Yemen", "YE", "887"),
      Country.CreateNew("Zambia", "ZM", "894"),
      Country.CreateNew("Zimbabwe", "ZW", "716")
   };
}