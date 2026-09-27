using UnityEngine;
using UnityEditor;

namespace UkuPacha
{
    public class DataCreator
    {
        #if UNITY_EDITOR
        [MenuItem("UkuPacha/Create Sample Souls")]
        public static void CreateSampleSouls()
        {
            string folderPath = "Assets/Resources/Souls";
            
            if (!AssetDatabase.IsValidFolder(folderPath))
                AssetDatabase.CreateFolder("Assets/Resources", "Souls");
            
            // 1. El Ejecutivo Piramidal
            CreateSoul(
                folderPath,
                "ExecutivoPiramidal",
                "El Ejecutivo Piramidal",
                "Hombre de negocio fraudulento con reloj falso",
                new DNIData
                {
                    name = "Carlos Mendoza",
                    age = 45,
                    occupation = "Empresario",
                    identityDeclaration = "Dueño de Piramidal Inc.",
                    isAuthentic = true
                },
                new CVData
                {
                    name = "Carlos Mendoza",
                    profession = "CEO",
                    yearsOfExperience = 20,
                    achievements = new[] { "Fundé Piramidal Inc.", "Invertí en Gold Club" },
                    crimes = new[]
                    {
                        new SoulCrime
                        {
                            description = "Reloj falsificado 'Rollex'",
                            visualEvidence = "Plástico barato, logo mal impreso",
                            lawBroken = AndineLawType.AmaLlulla
                        },
                        new SoulCrime
                        {
                            description = "Tarjetas de crédito de otros",
                            visualEvidence = "Nombres ajenos, múltiples tarjetas",
                            lawBroken = AndineLawType.AmaSua
                        }
                    }
                },
                new[] { AndineLawType.AmaLlulla, AndineLawType.AmaSua },
                isGoodSoul: false
            );
            
            CreateSoul(
                folderPath,
                "SeñoraChacrosa",
                "La Señora Chacrosa",
                "Vendedora de cuarzos falsos como auténticos",
                new DNIData
                {
                    name = "Rosa García",
                    age = 52,
                    occupation = "Vendedora de minerales",
                    identityDeclaration = "Experta en cuarzos naturales",
                    isAuthentic = true
                },
                new CVData
                {
                    name = "Rosa García",
                    profession = "Curadora de Cristales",
                    yearsOfExperience = 15,
                    achievements = new[] { "Vendo cristales 'auténticos'", "Prometo sanación espiritual" },
                    crimes = new[]
                    {
                        new SoulCrime
                        {
                            description = "Cuarzos con etiqueta 'Hecho en Gamarra'",
                            visualEvidence = "Etiqueta pegada recientemente, pegamento visible",
                            lawBroken = AndineLawType.AmaLlulla
                        },
                        new SoulCrime
                        {
                            description = "Fotos descargadas de Internet como propias",
                            visualEvidence = "Logo de Shutterstock en la esquina",
                            lawBroken = AndineLawType.AmaSua
                        }
                    }
                },
                new[] { AndineLawType.AmaLlulla, AndineLawType.AmaSua },
                isGoodSoul: false
            );

            // 3. El Pituquito 'Misio'
            CreateSoul(
                folderPath,
                "PituquitoMisio",
                "El Pituquito 'Misio'",
                "Niño mimado que vive del dinero de papá",
                new DNIData
                {
                    name = "Fernando Cortés",
                    age = 22,
                    occupation = "Estudiante",
                    identityDeclaration = "Independiente financiero",
                    isAuthentic = true
                },
                new CVData
                {
                    name = "Fernando Cortés",
                    profession = "Empresario junior",
                    yearsOfExperience = 0,
                    achievements = new[] { "Tengo mi propio negocio" },
                    crimes = new[]
                    {
                        new SoulCrime
                        {
                            description = "Dólares en bolsillos de pantalón",
                            visualEvidence = "Fajo de billetes reciente, no circulado",
                            lawBroken = AndineLawType.AmaSua
                        },
                        new SoulCrime
                        {
                            description = "Tarjetas de crédito a nombre del padre",
                            visualEvidence = "'Sr. Cortés Senior' en todas las tarjetas",
                            lawBroken = AndineLawType.AmaLlulla
                        }
                    }
                },
                new[] { AndineLawType.AmaLlulla, AndineLawType.AmaSua },
                isGoodSoul: false
            );

            // 4. El Tío Chelero
            CreateSoul(
                folderPath,
                "TioChelero",
                "El Tío Chelero",
                "Borracho negligente con obligaciones familiares",
                new DNIData
                {
                    name = "Roberto Jiménez",
                    age = 58,
                    occupation = "Obrero jubilado",
                    identityDeclaration = "Padre responsable",
                    isAuthentic = true
                },
                new CVData
                {
                    name = "Roberto Jiménez",
                    profession = "Ex-trabajador de construcción",
                    yearsOfExperience = 30,
                    achievements = new[] { "Trabajé 30 años", "Tengo 5 hijos" },
                    crimes = new[]
                    {
                        new SoulCrime
                        {
                            description = "Recibos de pensión de alimentos vencidos",
                            visualEvidence = "Papeles amarillos en caja de cervezas vacías",
                            lawBroken = AndineLawType.AmaQuela
                        }
                    }
                },
                new[] { AndineLawType.AmaQuela },
                isGoodSoul: false
            );

            // 5. El Chibolo Fifas
            CreateSoul(
                folderPath,
                "ChiboloFifas",
                "El Chibolo Fifas",
                "Adolescente que usa ropa falsificada",
                new DNIData
                {
                    name = "Diego López",
                    age = 16,
                    occupation = "Estudiante",
                    identityDeclaration = "Coleccionista de sneakers auténticos",
                    isAuthentic = true
                },
                new CVData
                {
                    name = "Diego López",
                    profession = "Influencer en redes",
                    yearsOfExperience = 1,
                    achievements = new[] { "10k followers en TikTok", "Todas mis zapatillas son Nike" },
                    crimes = new[]
                    {
                        new SoulCrime
                        {
                            description = "Zapatillas 'Adedos' (imitación de Adidas)",
                            visualEvidence = "Grabado mal hecho: 'Adedos' en lugar de 'Adidas'",
                            lawBroken = AndineLawType.AmaLlulla
                        }
                    }
                },
                new[] { AndineLawType.AmaLlulla },
                isGoodSoul: false
            );
            
            // 6. La Señora Religiosa
            CreateSoul(
                folderPath,
                "SeñoraReligiosa",
                "La Señora Religiosa",
                "Beata que chismea y roba información",
                new DNIData
                {
                    name = "María Delgado",
                    age = 61,
                    occupation = "Catequista",
                    identityDeclaration = "Mujer de fe y moral",
                    isAuthentic = true
                },
                new CVData
                {
                    name = "María Delgado",
                    profession = "Pastora Evangélica",
                    yearsOfExperience = 20,
                    achievements = new[] { "Guío 200 almas", "Distribuyo mensajes de Dios" },
                    crimes = new[]
                    {
                        new SoulCrime
                        {
                            description = "Micrófonos espía en bolso",
                            visualEvidence = "5 dispositivos de grabación ocultos",
                            lawBroken = AndineLawType.AmaSua
                        },
                        new SoulCrime
                        {
                            description = "Chismes documentados en recortes",
                            visualEvidence = "Carpeta de secretos de feligreses",
                            lawBroken = AndineLawType.AmaQuela
                        }
                    }
                },
                new[] { AndineLawType.AmaSua, AndineLawType.AmaQuela },
                isGoodSoul: false
            );
            
            AssetDatabase.Refresh();
        }

        private static void CreateSoul(string folderPath, string fileName, string stereotype, string description,
            DNIData dniData, CVData cvData, AndineLawType[] brokenLaws, bool isGoodSoul)
        {
            var soul = ScriptableObject.CreateInstance<SoulScriptable>();
            
            soul.soulStereotype = stereotype;
            soul.description = description;
            soul.dni = dniData;
            soul.cv = cvData;
            soul.actualLawsBroken = brokenLaws;
            soul.isGoodSoul = isGoodSoul;

            var assetPath = $"{folderPath}/{fileName}.asset";
            AssetDatabase.CreateAsset(soul, assetPath);
            
            Debug.Log($"✓ Creada: {stereotype}");
        }
        #endif
    }
}