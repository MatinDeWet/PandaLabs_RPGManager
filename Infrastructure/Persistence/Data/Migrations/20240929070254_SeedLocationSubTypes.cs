using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocationSubTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocationSubType",
                columns: new[] { "Id", "Group", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Abbey" },
                    { 2, 1, "Acropolis / Citadel" },
                    { 3, 1, "Airport" },
                    { 4, 1, "Alleyway" },
                    { 5, 1, "Allotment" },
                    { 6, 1, "Amphitheatre" },
                    { 7, 1, "Apartment" },
                    { 8, 1, "Apartment building / Tenament" },
                    { 9, 1, "Apothecary" },
                    { 10, 1, "Aqueduct" },
                    { 11, 1, "Arcade" },
                    { 12, 1, "Architectural Element, Catwalk" },
                    { 13, 1, "Architectural Element, Dungeon" },
                    { 14, 1, "Architectural Element, Entrance / Entryway" },
                    { 15, 1, "Architectural Element, Gallery" },
                    { 16, 1, "Architectural Element, Rooftop" },
                    { 17, 1, "Archive" },
                    { 18, 1, "Archway / Triumphal Arch" },
                    { 19, 1, "Arcology / Residential Complex" },
                    { 20, 1, "Arena" },
                    { 21, 1, "Arsenal" },
                    { 22, 1, "Art gallery" },
                    { 23, 1, "Asylum" },
                    { 24, 1, "Aviary" },
                    { 25, 1, "Bakery" },
                    { 26, 1, "Bank / Treasury" },
                    { 27, 1, "Bar" },
                    { 28, 1, "Barber / Dentist / Surgery" },
                    { 29, 1, "Barracks" },
                    { 30, 1, "Barrow / Burial Ground" },
                    { 31, 1, "Bathhouse" },
                    { 32, 1, "Battlesite / Battlefield" },
                    { 33, 1, "Bench" },
                    { 34, 1, "Boathouse / Wharf" },
                    { 35, 1, "Bookstore" },
                    { 36, 1, "Brewery / Winery" },
                    { 37, 1, "Bridge" },
                    { 38, 1, "Brothel / Whorehouse" },
                    { 39, 1, "Bunker" },
                    { 40, 1, "Cafe / Tearoom" },
                    { 41, 1, "Cairn" },
                    { 42, 1, "Canal" },
                    { 43, 1, "Canal Lock" },
                    { 44, 1, "Caravanserai" },
                    { 45, 1, "Casino" },
                    { 46, 1, "Castle" },
                    { 47, 1, "Catacomb" },
                    { 48, 1, "Cathedral / Great temple" },
                    { 49, 1, "Cemetery" },
                    { 50, 1, "Chapel" },
                    { 51, 1, "Circus" },
                    { 52, 1, "Clinic" },
                    { 53, 1, "Club" },
                    { 54, 1, "Coffee Shop" },
                    { 55, 1, "College / Academy" },
                    { 56, 1, "Common Area" },
                    { 57, 1, "Consulate" },
                    { 58, 1, "Cottage" },
                    { 59, 1, "Courthouse" },
                    { 60, 1, "Cowshed" },
                    { 61, 1, "Craftsman, Blacksmith / Smithy" },
                    { 62, 1, "Craftsman, Leatherworker" },
                    { 63, 1, "Craftsman, Tanner" },
                    { 64, 1, "Crypt" },
                    { 65, 1, "Customs House" },
                    { 66, 1, "Dam" },
                    { 67, 1, "Dance Club" },
                    { 68, 1, "Datacenter" },
                    { 69, 1, "Dojo" },
                    { 70, 1, "Drug Den" },
                    { 71, 1, "Dungeon" },
                    { 72, 1, "Embassy" },
                    { 73, 1, "Estate" },
                    { 74, 1, "Factory" },
                    { 75, 1, "Farm" },
                    { 76, 1, "Fishery" },
                    { 77, 1, "Footpath" },
                    { 78, 1, "Fort" },
                    { 79, 1, "Fortress" },
                    { 80, 1, "Forum" },
                    { 81, 1, "Foundry" },
                    { 82, 1, "Fountain" },
                    { 83, 1, "Garage" },
                    { 84, 1, "Garden" },
                    { 85, 1, "Gatehouse" },
                    { 86, 1, "Gazebo / Bandstand" },
                    { 87, 1, "General Store" },
                    { 88, 1, "Geographic Feature" },
                    { 89, 1, "Government Complex" },
                    { 90, 1, "Graveyard" },
                    { 91, 1, "Great Hall" },
                    { 92, 1, "Guard Post / House" },
                    { 93, 1, "Guildhall" },
                    { 94, 1, "Gym" },
                    { 95, 1, "Hangar, Massive" },
                    { 96, 1, "Henge" },
                    { 97, 1, "Hideout" },
                    { 98, 1, "Highway" },
                    { 99, 1, "Hospital" },
                    { 100, 1, "Hospitality, Camping" },
                    { 101, 1, "Hospitality, Hotel" },
                    { 102, 1, "Hospitality, Motel" },
                    { 103, 1, "Hospitality, Resort" },
                    { 104, 1, "Hospitality, Spa" },
                    { 105, 1, "House" },
                    { 107, 1, "Hut" },
                    { 108, 1, "Hydroponics / Agricultural Complex" },
                    { 109, 1, "Inn" },
                    { 110, 1, "Jeweler" },
                    { 111, 1, "Keep" },
                    { 112, 1, "Kiosk / Small Store" },
                    { 113, 1, "Laboratory" },
                    { 114, 1, "Laboratory, Magical" },
                    { 115, 1, "Lair" },
                    { 116, 1, "Landing Pad" },
                    { 117, 1, "Library" },
                    { 118, 1, "Lighthouse" },
                    { 119, 1, "Lodge, Cabin" },
                    { 120, 1, "Manor house / Meeting Hall" },
                    { 121, 1, "Mansion / Villa" },
                    { 122, 1, "Manufactory" },
                    { 123, 1, "Market square" },
                    { 124, 1, "Market stall" },
                    { 125, 1, "Megastructure, Dyson Sphere" },
                    { 126, 1, "Megastructure, Land Based" },
                    { 127, 1, "Megastructure, Orbital Scale" },
                    { 128, 1, "Megastructure, Planetary Scale" },
                    { 129, 1, "Megastructure, Stellar Scale" },
                    { 130, 1, "Megastructure, Trans-Orbital" },
                    { 131, 1, "Memorial / War Memorial" },
                    { 132, 1, "Military Base / Complex" },
                    { 133, 1, "Mill" },
                    { 134, 1, "Mine" },
                    { 135, 1, "Ministry / City Hall" },
                    { 136, 1, "Missile launch facility" },
                    { 137, 1, "Monastery" },
                    { 138, 1, "Monument / Statue" },
                    { 139, 1, "Monument" },
                    { 140, 1, "Museum" },
                    { 141, 1, "Natural Wonder" },
                    { 142, 1, "Observatory / Telescope" },
                    { 143, 1, "Office" },
                    { 144, 1, "Opera House" },
                    { 145, 1, "Orbital, Beacon / Buoy" },
                    { 146, 1, "Orbital, Halo / Ringworld" },
                    { 147, 1, "Orbital, Outpost" },
                    { 148, 1, "Orbital, Satelite" },
                    { 149, 1, "Orbital, Shipyard" },
                    { 150, 1, "Orbital, Space Elevator" },
                    { 151, 1, "Orbital, Station" },
                    { 152, 1, "Orbital, Way / Refueling Station" },
                    { 153, 1, "Orbital, Weapons Platform" },
                    { 154, 1, "Orphanage" },
                    { 155, 1, "Palace" },
                    { 156, 1, "Park" },
                    { 157, 1, "Parliament" },
                    { 158, 1, "Pier" },
                    { 159, 1, "Pigsty" },
                    { 160, 1, "Police/Fire Station" },
                    { 161, 1, "Portal" },
                    { 162, 1, "Post Office" },
                    { 163, 1, "Power Plant" },
                    { 164, 1, "Prison" },
                    { 165, 1, "Prison Camps" },
                    { 166, 1, "Pub / Tavern / Restaurant" },
                    { 167, 1, "Public Hall / House" },
                    { 168, 1, "Quarry" },
                    { 169, 1, "Racing Track / Hippodrome" },
                    { 170, 1, "Railroad" },
                    { 171, 1, "Refinery / Industrial Complex" },
                    { 172, 1, "Reliquary" },
                    { 173, 1, "Reservoir" },
                    { 174, 1, "Retirement Home" },
                    { 175, 1, "Road" },
                    { 176, 1, "Room, Animal, Apiary" },
                    { 177, 1, "Room, Animal, Aquarium" },
                    { 178, 1, "Room, Animal, Aviary" },
                    { 179, 1, "Room, Animal, Dovecot" },
                    { 180, 1, "Room, Animal, Enclosure" },
                    { 181, 1, "Room, Animal, Insect Room" },
                    { 182, 1, "Room, Animal, Menagerie" },
                    { 183, 1, "Room, Animal, Pen" },
                    { 184, 1, "Room, Animal, Stable" },
                    { 185, 1, "Room, Animal, Tackroom" },
                    { 186, 1, "Room, Chamber, Council" },
                    { 187, 1, "Room, Chamber, Execution" },
                    { 188, 1, "Room, Chamber, Teleportation" },
                    { 189, 1, "Room, Chamber, Torture" },
                    { 190, 1, "Room, Common, Antechamber" },
                    { 191, 1, "Room, Common, Attic" },
                    { 192, 1, "Room, Common, Balcony" },
                    { 193, 1, "Room, Common, Basement" },
                    { 194, 1, "Room, Common, Bathroom" },
                    { 195, 1, "Room, Common, Bedroom" },
                    { 196, 1, "Room, Common, Boiler Room" },
                    { 197, 1, "Room, Common, Boudoir" },
                    { 198, 1, "Room, Common, Broom Closet" },
                    { 199, 1, "Room, Common, Cellar" },
                    { 200, 1, "Room, Common, Cloak Room" },
                    { 201, 1, "Room, Common, Closet / Wardrobe" },
                    { 202, 1, "Room, Common, Conservatory" },
                    { 203, 1, "Room, Common, Dining Room" },
                    { 204, 1, "Room, Common, Dressing Room" },
                    { 205, 1, "Room, Common, Elevator / Lift" },
                    { 206, 1, "Room, Common, Family Room" },
                    { 207, 1, "Room, Common, Gameroom" },
                    { 208, 1, "Room, Common, Garage" },
                    { 209, 1, "Room, Common, Garderobe" },
                    { 210, 1, "Room, Common, Green Room" },
                    { 211, 1, "Room, Common, Hall" },
                    { 212, 1, "Room, Common, Kitchen" },
                    { 213, 1, "Room, Common, Living Room" },
                    { 214, 1, "Room, Common, Office" },
                    { 215, 1, "Room, Common, Pantry" },
                    { 216, 1, "Room, Common, Parlour" },
                    { 217, 1, "Room, Common, Reception" },
                    { 218, 1, "Room, Common, Sauna" },
                    { 219, 1, "Room, Common, Smoking Room" },
                    { 220, 1, "Room, Common, Solar" },
                    { 221, 1, "Room, Common, Spa" },
                    { 222, 1, "Room, Common, Stairwell / Staircase" },
                    { 223, 1, "Room, Common, Study" },
                    { 224, 1, "Room, Common, Swimming Pool" },
                    { 225, 1, "Room, Common, Tea Room" },
                    { 226, 1, "Room, Common, Toilet / WC" },
                    { 227, 1, "Room, Common, Undercroft" },
                    { 228, 1, "Room, Common, Utility Closet" },
                    { 229, 1, "Room, Common, Waiting Room" },
                    { 230, 1, "Room, Common, Washing Room / Laundry" },
                    { 231, 1, "Room, Common, Workshop" },
                    { 232, 1, "Room, Conference / Meeting Room" },
                    { 233, 1, "Room, Corridor, Junction" },
                    { 234, 1, "Room, Corridor, Section" },
                    { 235, 1, "Room, Corridor. Fork" },
                    { 236, 1, "Room, Court, Legal" },
                    { 237, 1, "Room, Dome, Living" },
                    { 238, 1, "Room, Dome, Terrarium" },
                    { 239, 1, "Room, Education, Auditorium" },
                    { 240, 1, "Room, Education, Classroom" },
                    { 241, 1, "Room, Education, Lecture Hall" },
                    { 242, 1, "Room, Education, Library" },
                    { 243, 1, "Room, Entertainment, Arcade" },
                    { 244, 1, "Room, Entertainment, Games Court" },
                    { 245, 1, "Room, Entertainment, Holodeck" },
                    { 246, 1, "Room, Entertainment, Ice Ring" },
                    { 247, 1, "Room, Entertainment, Playroom" },
                    { 248, 1, "Room, Hall, Banquet" },
                    { 249, 1, "Room, Hall, Dance" },
                    { 250, 1, "Room, Hall, Mead" },
                    { 251, 1, "Room, Hall, Throne Room" },
                    { 252, 1, "Room, Lab, Alchemical" },
                    { 253, 1, "Room, Lab, Chemistry" },
                    { 254, 1, "Room, Lab, Scientific" },
                    { 255, 1, "Room, Medical, Apothecary" },
                    { 256, 1, "Room, Medical, Delivery Room" },
                    { 257, 1, "Room, Medical, Diagnostic / Imaging" },
                    { 258, 1, "Room, Medical, ER" },
                    { 259, 1, "Room, Medical, Examination" },
                    { 260, 1, "Room, Medical, ICU" },
                    { 261, 1, "Room, Medical, Laboratory" },
                    { 262, 1, "Room, Medical, Nursery" },
                    { 263, 1, "Room, Medical, Recovery Room" },
                    { 264, 1, "Room, Medical, Surgery Theatre" },
                    { 265, 1, "Room, Medical, Ward" },
                    { 266, 1, "Room, Military, Armoury" },
                    { 267, 1, "Room, Military, Command & Amp" },
                    { 268, 1, "Room, Military, Gatehouse" },
                    { 269, 1, "Room, Military, Guardhouse" },
                    { 270, 1, "Room, Military, Mess Hall" },
                    { 271, 1, "Room, Military, Wall Section" },
                    { 272, 1, "Room, Military, War Room" },
                    { 273, 1, "Room, Natural, Cavern" },
                    { 274, 1, "Room, Outdoors, Alleyway" },
                    { 275, 1, "Room, Outdoors, Allotment" },
                    { 276, 1, "Room, Outdoors, Court" },
                    { 277, 1, "Room, Outdoors, Courtyard" },
                    { 278, 1, "Room, Outdoors, Garden" },
                    { 279, 1, "Room, Outdoors, Greenhouse" },
                    { 280, 1, "Room, Outdoors, Swimming Pool" },
                    { 281, 1, "Room, Religious, Aisles" },
                    { 282, 1, "Room, Religious, Apse" },
                    { 283, 1, "Room, Religious, Chancel" },
                    { 284, 1, "Room, Religious, Chapel" },
                    { 285, 1, "Room, Religious, Choir Stalls" },
                    { 286, 1, "Room, Religious, Clerestory" },
                    { 287, 1, "Room, Religious, Loft" },
                    { 288, 1, "Room, Religious, Mausoleum" },
                    { 289, 1, "Room, Religious, Monastic Cell" },
                    { 290, 1, "Room, Religious, Nave" },
                    { 291, 1, "Room, Religious, Pulpit" },
                    { 292, 1, "Room, Religious, Sanctuary" },
                    { 293, 1, "Room, Religious, Sanctum / Septum" },
                    { 294, 1, "Room, Religious, Shrine" },
                    { 295, 1, "Room, Religious, Steeple" },
                    { 296, 1, "Room, Religious, Tomb" },
                    { 297, 1, "Room, Religious, Transept" },
                    { 298, 1, "Room, Religious, Triforium" },
                    { 299, 1, "Room, Religious, Vestry" },
                    { 300, 1, "Room, Scientific, Laboratory" },
                    { 301, 1, "Room, Secret, Chamber" },
                    { 302, 1, "Room, Secret, Entry" },
                    { 303, 1, "Room, Secret, Passage" },
                    { 304, 1, "Room, Security, Cell" },
                    { 305, 1, "Room, Security, Safe" },
                    { 306, 1, "Room, Security, Saferoom" },
                    { 307, 1, "Room, Security, Treasury / Treasure Room" },
                    { 308, 1, "Room, Security, Vault" },
                    { 309, 1, "Room, Ship, Armourer Citadel" },
                    { 310, 1, "Room, Ship, Armoury" },
                    { 311, 1, "Room, Ship, Bilge" },
                    { 312, 1, "Room, Ship, Bridge" },
                    { 313, 1, "Room, Ship, Cabin" },
                    { 314, 1, "Room, Ship, Caboose" },
                    { 315, 1, "Room, Ship, Cannon / Gun Deck" },
                    { 316, 1, "Room, Ship, Deck" },
                    { 317, 1, "Room, Ship, Engine Room" },
                    { 318, 1, "Room, Ship, Fire Room" },
                    { 319, 1, "Room, Ship, Flying Bridge" },
                    { 320, 1, "Room, Ship, Forecastle" },
                    { 321, 1, "Room, Ship, Galley" },
                    { 322, 1, "Room, Ship, Gangway" },
                    { 323, 1, "Room, Ship, Gunroom" },
                    { 324, 1, "Room, Ship, Hold" },
                    { 325, 1, "Room, Ship, Magazine" },
                    { 326, 1, "Room, Ship, Maproom" },
                    { 327, 1, "Room, Ship, Navigation" },
                    { 328, 1, "Room, Ship, Operations" },
                    { 329, 1, "Room, Ship, Orlop" },
                    { 330, 1, "Room, Ship, Prominade" },
                    { 331, 1, "Room, Ship, Quarters, Captain" },
                    { 332, 1, "Room, Ship, Quarters, Crew" },
                    { 333, 1, "Room, Ship, Quarters, Officer" },
                    { 334, 1, "Room, Ship, Saferoom" },
                    { 335, 1, "Room, Ship, Sick Bay" },
                    { 336, 1, "Room, Ship, Steerage" },
                    { 337, 1, "Room, Ship, Wardroom" },
                    { 338, 1, "Room, Special, Buttery" },
                    { 339, 1, "Room, Special, Catacomb" },
                    { 340, 1, "Room, Special, Counting House" },
                    { 341, 1, "Room, Special, Crawlspace / Jefferies Tube" },
                    { 342, 1, "Room, Special, Crypt" },
                    { 343, 1, "Room, Special, Engineering" },
                    { 344, 1, "Room, Special, Factory Floor" },
                    { 345, 1, "Room, Special, Forge" },
                    { 346, 1, "Room, Special, Furnace / Incinerator" },
                    { 347, 1, "Room, Special, Ice House" },
                    { 348, 1, "Room, Special, Observatory" },
                    { 349, 1, "Room, Special, Oratory / Solar" },
                    { 350, 1, "Room, Special, Postroom" },
                    { 351, 1, "Room, Special, Scullery" },
                    { 352, 1, "Room, Special, Server Room" },
                    { 353, 1, "Room, Special, Trophies Room" },
                    { 354, 1, "Room, Storage, Freezer" },
                    { 355, 1, "Room, Storage, Loading Bay" },
                    { 356, 1, "Room, Storage, Other" },
                    { 357, 1, "Room, Storage, Warehouse" },
                    { 358, 1, "Room, Studio, Art" },
                    { 359, 1, "Room, Studio, Film" },
                    { 360, 1, "Room, Studio, Music" },
                    { 361, 1, "Room, Studio, Other" },
                    { 362, 1, "Room, Theatre, Box" },
                    { 363, 1, "Room, Theatre, Hall" },
                    { 364, 1, "Room, Theatre, Home" },
                    { 365, 1, "Room, Theatre, Stage" },
                    { 366, 1, "Room, Tower, Clock" },
                    { 367, 1, "Room, Tower, Other" },
                    { 368, 1, "Room, Tower, Wizard" },
                    { 369, 1, "Room, Training, Gym" },
                    { 370, 1, "Room, Training, Sparring" },
                    { 371, 1, "Ruins" },
                    { 372, 1, "School" },
                    { 373, 1, "Seaport" },
                    { 374, 1, "Sewer, Network" },
                    { 375, 1, "Sewer, Section" },
                    { 376, 1, "Shed" },
                    { 377, 1, "Sheepfold" },
                    { 378, 1, "Shelter" },
                    { 379, 1, "Shop, Cobbler" },
                    { 380, 1, "Shop, Generic" },
                    { 381, 1, "Shop, Magic" },
                    { 382, 1, "Shop, Tailor" },
                    { 383, 1, "Shopping Mall / Commercial Complex" },
                    { 384, 1, "Shrine" },
                    { 385, 1, "Skyscraper" },
                    { 386, 1, "Slaughterhouse" },
                    { 387, 1, "Smelter" },
                    { 388, 1, "Spaceport" },
                    { 389, 1, "Spot" },
                    { 390, 1, "Stables" },
                    { 391, 1, "Stadium" },
                    { 392, 1, "Statue" },
                    { 393, 1, "Storage House / Silo" },
                    { 394, 1, "Store" },
                    { 395, 1, "Street" },
                    { 396, 1, "Supermarket / Megastore" },
                    { 397, 1, "Tattoo Parlor" },
                    { 398, 1, "Technology Complex" },
                    { 399, 1, "Temple / Church" },
                    { 400, 1, "Temple / Religious Complex" },
                    { 401, 1, "Theatre / Concert Hall" },
                    { 402, 1, "Theme park / Entertainment Complex" },
                    { 403, 1, "Timberyard" },
                    { 404, 1, "Tolls" },
                    { 405, 1, "Tomb" },
                    { 406, 1, "Tower" },
                    { 407, 1, "Tower, Guard" },
                    { 408, 1, "Tower, Mage" },
                    { 409, 1, "Tower, Telecomms" },
                    { 410, 1, "Tower, Wall" },
                    { 411, 1, "Tower, Water" },
                    { 412, 1, "Transportation Hub" },
                    { 413, 1, "Transportation Station" },
                    { 414, 1, "Tree" },
                    { 415, 1, "Tree house" },
                    { 416, 1, "Tunnel" },
                    { 417, 1, "University / Educational Complex" },
                    { 418, 1, "Vehicle, Ship" },
                    { 419, 1, "Vehicle, Spaceship" },
                    { 420, 1, "Viewpoint" },
                    { 421, 1, "Vineyard / Orchard" },
                    { 422, 1, "Wall Section" },
                    { 423, 1, "Warehouse / Granary" },
                    { 424, 1, "Warehouse, Commercial" },
                    { 425, 1, "Warehouse, Industrial" },
                    { 426, 1, "Warehouse, Massive / Storage Complex" },
                    { 427, 1, "Warehouse, Residential" },
                    { 428, 1, "Water pump / Well" },
                    { 429, 1, "Well" },
                    { 430, 1, "Workshop" },
                    { 431, 1, "World wonder" },
                    { 432, 2, "Arcology" },
                    { 433, 2, "Camp, Temporary" },
                    { 434, 2, "Capital" },
                    { 435, 2, "Caravan" },
                    { 436, 2, "Citadel" },
                    { 437, 2, "City" },
                    { 438, 2, "Conurbation" },
                    { 439, 2, "District" },
                    { 440, 2, "Ecumenopolis" },
                    { 441, 2, "Hamlet" },
                    { 442, 2, "Large City" },
                    { 443, 2, "Large Town" },
                    { 444, 2, "Megalopolis" },
                    { 445, 2, "Metropolis" },
                    { 446, 2, "Military, Base" },
                    { 447, 2, "Military, Camp" },
                    { 448, 2, "National Territory" },
                    { 449, 2, "Neighbourhood" },
                    { 450, 2, "Orbital, Station" },
                    { 451, 2, "Outpost / Base" },
                    { 452, 2, "Quarter" },
                    { 453, 2, "Slum" },
                    { 454, 2, "Starbase" },
                    { 455, 2, "State" },
                    { 456, 2, "Town" },
                    { 457, 2, "Trade Post" },
                    { 458, 2, "Underground / Vault" },
                    { 459, 2, "Village" },
                    { 460, 2, "Ward" },
                    { 461, 3, "Abyss" },
                    { 462, 3, "Archipelago" },
                    { 463, 3, "Asteroid" },
                    { 464, 3, "Asteroid Belt" },
                    { 465, 3, "Atoll, Underwater" },
                    { 466, 3, "Badlands" },
                    { 467, 3, "Bay" },
                    { 468, 3, "Black Hole" },
                    { 469, 3, "Bodden" },
                    { 470, 3, "Brush" },
                    { 471, 3, "Canyon" },
                    { 472, 3, "Cape" },
                    { 473, 3, "Cave" },
                    { 474, 3, "Cave System" },
                    { 475, 3, "Chasm, Underwater" },
                    { 476, 3, "Cliff" },
                    { 477, 3, "Coast / Shore" },
                    { 478, 3, "Continent" },
                    { 479, 3, "Copse" },
                    { 480, 3, "Coral Reef, Atoll" },
                    { 481, 3, "Coral Reef, Barrier" },
                    { 482, 3, "Coral Reef, Fringing" },
                    { 483, 3, "Coral Reef, Platform" },
                    { 484, 3, "Cove" },
                    { 485, 3, "Cracked Planet" },
                    { 486, 3, "Crater / Crater Lake / Caldera" },
                    { 487, 3, "Desert" },
                    { 488, 3, "Desert, Ice" },
                    { 489, 3, "Dimensional Plane" },
                    { 490, 3, "Dimensional, Pocket" },
                    { 491, 3, "Estuary / River Delta" },
                    { 492, 3, "Expanse" },
                    { 493, 3, "Field" },
                    { 494, 3, "Fjord" },
                    { 495, 3, "Forest" },
                    { 496, 3, "Forest, Boreal (Coniferous)" },
                    { 497, 3, "Forest, Cloud / Water (Subtropical)" },
                    { 498, 3, "Forest, Jungle (Tropical)" },
                    { 499, 3, "Forest, Temperate (Seasonal)" },
                    { 500, 3, "Galactic Nebula" },
                    { 501, 3, "Galactic Quadrant" },
                    { 502, 3, "Galactic Sector" },
                    { 503, 3, "Galaxy" },
                    { 504, 3, "Galaxy Cluster" },
                    { 505, 3, "Galaxy Supercluster" },
                    { 506, 3, "Glacier" },
                    { 507, 3, "Gorge / Rift" },
                    { 508, 3, "Grassland" },
                    { 509, 3, "Grove" },
                    { 510, 3, "Gulf / Lagoon" },
                    { 511, 3, "Highlands" },
                    { 512, 3, "Inland Sea" },
                    { 513, 3, "Island" },
                    { 514, 3, "Island, Floating" },
                    { 515, 3, "Isthmus" },
                    { 516, 3, "Jungle" },
                    { 517, 3, "Lake" },
                    { 518, 3, "Lake, Dry" },
                    { 519, 3, "Landmass" },
                    { 520, 3, "Lava River" },
                    { 521, 3, "Magical Realm" },
                    { 522, 3, "Meadow" },
                    { 523, 3, "Megastructure" },
                    { 524, 3, "Moor" },
                    { 525, 3, "Mountain / Hill" },
                    { 526, 3, "Mountain Pass" },
                    { 527, 3, "Mountain Range" },
                    { 528, 3, "Multiverse" },
                    { 529, 3, "My Butt" },
                    { 530, 3, "Natural Wonder" },
                    { 531, 3, "Nebula" },
                    { 532, 3, "Oasis" },
                    { 533, 3, "Ocean" },
                    { 534, 3, "Peninsula" },
                    { 535, 3, "Plain" },
                    { 536, 3, "Planar Sphere/Grouping" },
                    { 537, 3, "Plane Of Existence" },
                    { 538, 3, "Planet" },
                    { 539, 3, "Planetary Orbit" },
                    { 540, 3, "Planetary Ring" },
                    { 541, 3, "Planetoid" },
                    { 542, 3, "Planetoid / Moon" },
                    { 543, 3, "Planetoid, Rogue" },
                    { 544, 3, "Plateau" },
                    { 545, 3, "Pocket Universe" },
                    { 546, 3, "Pond" },
                    { 547, 3, "Rapids" },
                    { 548, 3, "Region" },
                    { 549, 3, "River" },
                    { 550, 3, "River Basin" },
                    { 551, 3, "Rock Formation" },
                    { 552, 3, "Rolling Hills" },
                    { 553, 3, "Salt flat" },
                    { 554, 3, "Savannah" },
                    { 555, 3, "Sea" },
                    { 556, 3, "Shoal" },
                    { 557, 3, "Simulation" },
                    { 558, 3, "Sinkhole" },
                    { 559, 3, "Solar System" },
                    { 560, 3, "Space Station" },
                    { 561, 3, "Spring" },
                    { 562, 3, "Star" },
                    { 563, 3, "Star System" },
                    { 564, 3, "Star System Sector" },
                    { 565, 3, "Steppe" },
                    { 566, 3, "Strait" },
                    { 567, 3, "Stream" },
                    { 568, 3, "Subcontinent" },
                    { 569, 3, "Summit" },
                    { 570, 3, "Supercontinent" },
                    { 571, 3, "Taiga" },
                    { 572, 3, "Territory" },
                    { 573, 3, "Theatre" },
                    { 574, 3, "Tundra" },
                    { 575, 3, "Underground / Subterranean" },
                    { 576, 3, "Universe" },
                    { 577, 3, "Vale" },
                    { 578, 3, "Valley" },
                    { 579, 3, "Void" },
                    { 580, 3, "Volcano" },
                    { 581, 3, "Volcano, Underwater" },
                    { 582, 3, "Wasteland" },
                    { 583, 3, "Waterfall" },
                    { 584, 3, "Wetland / Swamp" },
                    { 585, 3, "Woods" },
                    { 586, 3, "World" },
                    { 587, 3, "Wormhole" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "LocationSubType",
                keyColumn: "Id",
                keyValue: 587);
        }
    }
}
