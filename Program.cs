
/* IMotor: Tiene un método Tipo() que retorna el tipo de motor.*/
public interface IMotor
{
    string Tipo();
}
/*IRuedas: Tiene un método Tipo() que retorna el tipo de ruedas.*/
public interface IRuedas
{
    string Tipo();
}
/*ICarroceria: Tiene un método Tipo() que retorna el tipo de carrocería.*/
public interface ICarroceria
{
    string Tipo();
}
/*IFabricaVehiculo: Define métodos para crear cada uno de los componentes de un vehículo (motor, ruedas y carrocería).*/
public interface IFabricaVehiculo
{
    IMotor CrearMotor();
    IRuedas CrearRuedas();
    ICarroceria CrearCarroceria();

}/* MotorAuto y MotorMoto implementan IMotor.*/
public class MotorAuto : IMotor
{
    public string Tipo() => "Motor de Auto";
}
/*RuedasAuto y RuedasMoto implementan IRuedas.*/
public class RuedasAuto : IRuedas
{
    public string Tipo() => "Ruedas de Auto";
}
/* CarroceriaAuto y CarroceriaMoto implementan ICarroceria.*/
public class CarroceriaAuto : ICarroceria
{
    public string Tipo() => "Carrocería de Auto";
}
/*Cada clase concreta define el método Tipo() que retorna una cadena específica.*/
public class MotorMoto : IMotor
{
    public string Tipo() => "Motor de Motocicleta";
}

public class RuedasMoto : IRuedas
{
    public string Tipo() => "Ruedas de Motocicleta";
}

public class CarroceriaMoto : ICarroceria
{
    public string Tipo() => "Carrocería de Motocicleta";
}
public class FabricaAuto : IFabricaVehiculo
{
    public IMotor CrearMotor()
    {
        return new MotorAuto();
    }

    public IRuedas CrearRuedas()
    {
        return new RuedasAuto();
    }

    public ICarroceria CrearCarroceria()
    {
        return new CarroceriaAuto();
    }
}
public class FabricaMoto : IFabricaVehiculo
{
    public IMotor CrearMotor()
    {
        return new MotorMoto();
    }

    public IRuedas CrearRuedas()
    {
        return new RuedasMoto();
    }

    public ICarroceria CrearCarroceria()
    {
        return new CarroceriaMoto();
    }
}
public class EnsambladorVehiculo
{
    private readonly IMotor _motor;
    private readonly IRuedas _ruedas;
    private readonly ICarroceria _carroceria;

    public EnsambladorVehiculo(IFabricaVehiculo fabrica)
    {
        _motor = fabrica.CrearMotor();
        _ruedas = fabrica.CrearRuedas();
        _carroceria = fabrica.CrearCarroceria();
    }

    public string EnsamblarVehiculo()
    {
        return $"Vehículo ensamblado con {_motor.Tipo()}, {_ruedas.Tipo()} y {_carroceria.Tipo()}.";
    }
}
public class program
{
    static void Main()
    {
        IFabricaVehiculo fabricaAuto = new FabricaAuto();
        EnsambladorVehiculo ensambladorAuto = new EnsambladorVehiculo(fabricaAuto);
        Console.WriteLine(ensambladorAuto.EnsamblarVehiculo());
        IFabricaVehiculo fabricaMoto = new FabricaMoto();
        EnsambladorVehiculo ensambladorMoto = new EnsambladorVehiculo(fabricaMoto);
        Console.WriteLine(ensambladorMoto.EnsamblarVehiculo());
    }
}