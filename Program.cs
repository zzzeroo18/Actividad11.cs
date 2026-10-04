using System;

// 1. Crear CuentaBancaria con saldo privado y metodos Depositar/Retirar.
// 2. Demostrar que saldo no es accesible directamente desde afuera.
// 3. Agregar validacion en Retirar: no retirar mas del saldo.
// 4. Crear clase Temperatura con propiedad que valide > -273.
// 5. Usar const para IVA = 0.21m.
// 6. Usar readonly para el ID de cuenta generado en constructor.
// 7. Crear propiedad de solo escritura (solo set).
// 8. Crear propiedad calculada: Perimetro => 2 * (Ancho + Alto).
// 9. Agregar propiedad Edad con validacion 0 a 150.
// 10. Crear clase Persona con todas las propiedades correctamente encapsuladas.

namespace act11
{
    public class CuentaBancaria
    {
        private decimal saldo;
        private readonly string idcuenta;

        public string IdCuenta => idcuenta;

        public CuentaBancaria(string idCuenta)
        {
            idcuenta = idCuenta;
            saldo = 0;
        }

        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                saldo += monto;
                Console.WriteLine($"Se depositaron: ${monto} correctamente.");
            }
        }

        public void Retirar(decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("El monto a retirar debe ser mayor a 0.");
            }
            else if (monto > saldo)
            {
                Console.WriteLine("Fondos insuficientes.");
            }
            else
            {
                saldo -= monto;
                Console.WriteLine($"Se retiraron: ${monto} correctamente.");
            }
        }
    }

    public class Temperatura
    {
        private double _celsius;

        public double Celsius
        {
            get => _celsius;
            set
            {
                if (value < -273.15)
                {
                    Console.WriteLine("Error: La temperatura no puede ser menor a -273.15 °C.");
                }
                else
                {
                    _celsius = value;
                }
            }
        }
    }

    public class Impuestos
    {
        public const decimal IVA = 0.21m;
    }

    public class ReglaAuditoria
    {
        private string _claveSecreta = string.Empty;

        public string ClaveAcceso
        {
            set => _claveSecreta = value;
        }
    }

    public class Rectangulo
    {
        public double Ancho { get; set; }
        public double Alto { get; set; }

        public double Perimetro => 2 * (Ancho + Alto);
    }

    public class Persona
    {
        private string _nombre = string.Empty;
        private int _edad;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nombre = value;
                }
                else
                {
                    Console.WriteLine("El nombre no puede estar vacio ni ser un espacio.");
                }
            }
        }

        public int Edad
        {
            get => _edad;
            set
            {
                if (value >= 0 && value <= 150)
                {
                    _edad = value;
                }
                else
                {
                    Console.WriteLine("La edad debe estar entre 0 y 150 años.");
                }
            }
        }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
    }

    class Program
    {
        static void Main()
        {
            // 1, 3 y 6. Probar CuentaBancaria con saldo, deposito, retiro y readonly ID
            Console.WriteLine("Consignas 1, 3 y 6");
            CuentaBancaria miCuenta = new CuentaBancaria("001");
            Console.WriteLine($"ID de cuenta (readonly): {miCuenta.IdCuenta}");
            miCuenta.Depositar(100000m);
            miCuenta.Retirar(2000m);
            miCuenta.Retirar(150000m); // Prueba de validacion fondos insuficientes
            Console.WriteLine();

            // 2. Demostrar que saldo es privado
            Console.WriteLine("Consigna 2");
            // Console.WriteLine(miCuenta.saldo); // ERROR: 'CuentaBancaria.saldo' es inaccesible debido a su nivel de proteccion.
            Console.WriteLine("El atributo 'saldo' es privado y no se puede consultar directamente desde Main.\n");

            // 4. Probar Temperatura con validacion > -273.15
            Console.WriteLine(" Consigna 4 ");
            Temperatura temp = new Temperatura();
            temp.Celsius = 25.0;
            Console.WriteLine($"Temperatura: {temp.Celsius} °C");
            temp.Celsius = -300; // Intento de asignacion invalida
            Console.WriteLine();

            // 5. Constante IVA
            Console.WriteLine(" Consigna 5 ");
            decimal precio = 500m;
            decimal total = precio * (1 + Impuestos.IVA);
            Console.WriteLine($"Precio: ${precio} | IVA: {Impuestos.IVA * 100}% | Total: ${total}\n");

            // 7. Propiedad solo escritura
            Console.WriteLine(" Consigna 7 ");
            ReglaAuditoria auditoria = new ReglaAuditoria();
            auditoria.ClaveAcceso = "MiClaveSuperSegura123";
            Console.WriteLine("Clave asignada mediante propiedad con solo 'set'.\n");

            // 8. Propiedad calculada Perimetro
            Console.WriteLine(" Consigna 8 ");
            Rectangulo rect = new Rectangulo();
            rect.Ancho = 10.0;
            rect.Alto = 5.0;
            Console.WriteLine($"Rectangulo {rect.Ancho}x{rect.Alto} -> Perimetro: {rect.Perimetro}\n");

            // 9 y 10. Clase Persona con encapsulamiento completo y validaciones
            Console.WriteLine(" Consignas 9 y 10 ");
            Persona p1 = new Persona("Bauticasimiro", 19);
            Console.WriteLine($"Persona creada: {p1.Nombre}, {p1.Edad} años.");

            Persona p2 = new Persona("", 200); // Muestra los mensajes de error del set
            Console.WriteLine();
        }
    }
}