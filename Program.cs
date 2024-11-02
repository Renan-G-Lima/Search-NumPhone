using OpenCage.Geocode;
using PhoneNumbers;

class Program
{
    static void Main(string[] args)
    {
        // Parte 1: Validação e extração de informações do número de telefone
        var phoneNumber = "+5551986874294";
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

        try
        {
            // Parse o número de telefone
            PhoneNumber number = phoneUtil.Parse(phoneNumber, null);

            // Verifique se o número é válido
            if (phoneUtil.IsValidNumber(number))
            {
                // Obtenha informações sobre o número
                Console.WriteLine($"Número: {phoneUtil.Format(number, PhoneNumberFormat.E164)}");
                Console.WriteLine($"Tipo: {phoneUtil.GetNumberType(number)}");
                Console.WriteLine($"Região: {phoneUtil.GetRegionCodeForNumber(number)}");
            }
            else
            {
                Console.WriteLine("Número de telefone inválido.");
            }
        }
        catch (NumberParseException e)
        {
            Console.WriteLine($"Erro ao analisar o número: {e.Message}");
        }

        // Parte 2: Geocodificação usando OpenCage
        var passkey = new Geocoder("c5f8e9a5351d4bc4b47f0e7bf708f665");

        // Geocodificação de um endereço
        var addressResult = passkey.Geocode("82 Clerkenwell Road, London");
        if (addressResult != null)
        {
            Console.WriteLine($"Geocodificação para endereço: {addressResult}");
        }
        else
        {
            Console.WriteLine("Nenhum resultado encontrado para o endereço.");
        }

        // Geocodificação reversa usando coordenadas
        var reverseResult = passkey.ReverseGeocode(51.4277844, -0.3336517);
        if (reverseResult != null)
        {
            Console.WriteLine($"Geocodificação reversa: {reverseResult}");
        }
        else
        {
            Console.WriteLine("Nenhum resultado encontrado para as coordenadas.");
        }
    }
}