using System;

namespace Ailos.Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--> Verifica listas possivelmente nulas de maneiras diferentes");
            NullList();

            Console.WriteLine("--> Gera alerta do compilador ao adicionar null em uma propriedade marcada com [DisallowNull]");
            DisallowNull();

            Console.WriteLine("--> Verifica o objeto nulo em um método separado do fluxo");
            NullableObject();

            Console.ReadKey();
        }

        /// <summary>
        /// Verifica listas possivelmente nulas de maneiras diferentes
        /// </summary>
        private static void NullList()
        {
            CustomerRepository repository = new();

            // Verificando lista antes de utiliza-lá
            var all = repository.GetAll();

            if (all is not null)
            {
                foreach (var item in all)
                {
                    Console.WriteLine("Item: " + item);
                }
            }

            // Utilizando o operador "!" para suprimir o alerta
            foreach (var item in repository.GetAll()!)
            {
                Console.WriteLine("Item: " + item);
            }
        }

        /// <summary>
        /// Gera alerta do compilador ao adicionar null em uma propriedade marcada com [DisallowNull]
        /// </summary>
        private static void DisallowNull()
        {
            var model = new CustomerViewModel
            {
                Address = null
            };

            Console.WriteLine($"Address: " + model.Address);
        }

        /// <summary>
        /// Verifica o objeto nulo em um método separado do fluxo
        /// </summary>
        private static void NullableObject()
        {
            CustomerViewModel? model = null;

            if (IsValid(model))
            {
                var fullName2 = model!.FullName; // precisa do operador "!" para informar ao compilador que não será nulo
                Console.WriteLine("FullName Null: " + fullName2);
            }

            model = new CustomerViewModel
            {
                FirstName = "Hércules"
            };

            string middleName = model.MiddleName;
            string lastName = model.LastName;

            var fullName = model.FullName;
            Console.WriteLine("FullName: " + fullName);

            static bool IsValid(CustomerViewModel? obj) => obj is not null;
        }
    }
}
