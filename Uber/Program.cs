using System;
using System.Collections.Generic;
using System.Threading;

namespace Uber
{
    internal class Program
    {
        static Motorista[] motoristas = new Motorista[5];

        static void Main(string[] args)
        {
            instanciarMotoristas();

            //motorista 3 fica indisponivel
            motoristas[3].alterarStatus(StatusMotorista.statusMotorista.indisponível, false);

            executarSituacao0();



            //Console.WriteLine("MOTORISTAS DISPONÍVEIS =>\n");
            //mostrarMotoristas(StatusMotorista.statusMotorista.disponível);

            

            

            //Situação 1: passageiro solicita corrida e paga com cartão de crédito,
            //            a corrida é finalizada sem alteração no valor
            //executarSituacao1();

            ////Situação 2: passageiro solicita corrida e paga com cartão de crédito,
            ////            a corrida é finalizada com alteração no valor
            //executarSituacao2();

            ////Situação 3: passageiro solicita corrida e paga com cashUber, ele tem saldo,
            ////            a corrida é finalizada sem alteração no valor
            //executarSituacao3();

            ////Situação 4: passageiro solicita corrida e paga com cashUber, ele tem saldo,
            ////            a corrida é finalizada com alteração no valor e ele tem saldo pra diferença
            //executarSituacao4();

            ////Situação 5: passageiro solicita corrida e paga com cashUber, ele não tem saldo,
            ////            a corrida é cancelada
            //executarSituacao5();

            ////Situação 6: passageiro solicita corrida e paga com cashUber, ele tem saldo,
            ////            a corrida é finalizada com alteração no valor e ele não tem saldo pra diferença
            //executarSituacao6();

            ////Situação 7: passageiro solicita corrida e paga com dinheiro,
            ////            a corrida é finalizada sem alteração de valor
            //executarSituacao7();

            ////Situação 8: passageiro solicita corrida e paga com dinheiro,
            ////            a corrida é finalizada com alteração de valor
            //executarSituacao8();

            ////Situação 9: passageiro solicita corrida, vê o valor e cancela a corrida
            //executarSituacao9();

        }


        public static void instanciarMotoristas()
        {
            motoristas[0] = new Motorista();
            motoristas[0].cpf = "120.909.698-65";
            motoristas[0].nome = "Fernando";
            motoristas[0].celular = "1196162-9596";
            motoristas[0].email = "fernando@gmail.com";
            motoristas[0].senha = "123";
            motoristas[0].carro = new Carro("Chevrolet", "Cruze", "ABC1234", "Preto");

            //
            motoristas[1] = (new Motorista("148.953.847-85", "Henrique", "1198485-6936", "henrique@gmail.com", "785", new Carro("Honda", "Fit", "ERF7859", "Branco")));
            motoristas[2] = (new Motorista("125.485.962-00", "Ana", "1196385-4825", "ana@gmail.com", "369", new Carro("Citroen", "C4", "FRD4856", "Vermelho")));
            motoristas[3] = (new Motorista("196.785.486-65", "Caique", "1192233-8855", "caique@gmail.com", "245", new Carro("Toyota", "Corolla", "CDC1526", "Azul")));
            motoristas[4] = (new Motorista("111.222.333-85", "Joana", "1198855-4763", "joana@gmail.com", "796", new Carro("Volkswagen", "Gol", "PLN4856", "Cinza")));
        } 

        public static void mostrarMotoristas()
        {
            foreach (Motorista m in motoristas)
            {
                Console.WriteLine(m.mostrar());
            }
        }

        public static void mostrarMotoristas(StatusMotorista.statusMotorista status)
        {
            foreach (Motorista m in motoristas)
            {
                if (m.status == status)
                {
                    Console.WriteLine(m.mostrar());
                }
            }
        }

        public static void executarSituacao0()
        {
            string opcao;
            string endereco;
            string[] camposEndereco;
            Endereco origem;
            Endereco destino;
            Enum.FormaPagto formaPagto = Enum.FormaPagto.dinheiro;

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 100);

            Console.WriteLine($"Olá {passageiro1.nome}, deseja realizar uma corrida ? (Digite 'S' ou 'N')");

            opcao = Console.ReadLine().ToUpper().Trim();
            if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

            if (opcao == "S")
            {
                //endereco origem
                Console.WriteLine("Sua localização atual será o endereço de origem ? (Digite 'S' ou 'N')");

                opcao = Console.ReadLine().ToUpper().Trim();
                if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

                if (opcao == "S")
                {
                    origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
                } else 
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor informe o endereço de origem utilizando o formato abaixo\n" +
                                      "(logradouro/numero/complemento/bairro/cidade/estado/cep)");

                    endereco = Console.ReadLine();
                    camposEndereco = endereco.Split('/');

                    origem = new Endereco(camposEndereco);
                }

                //endereco destino
                Console.WriteLine();
                Console.WriteLine("Por favor informe o endereço de destino utilizando o formato abaixo\n" +
                                  "(logradouro/numero/complemento/bairro/cidade/estado/cep)");

                endereco = Console.ReadLine();
                camposEndereco = endereco.Split('/');

                destino = new Endereco(camposEndereco);

                //
               // passageiro1.solicitarCorrida(origem, destino);

                Console.WriteLine();
                Console.WriteLine($"Qual será a forma de Pagamento ? \n" +
                                  $"   1 - {Enum.FormaPagto.dinheiro} \n" +
                                  $"   2 - {Enum.FormaPagto.crédito} \n" +
                                  $"   3 - {Enum.FormaPagto.cashUber}");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": 
                        formaPagto = Enum.FormaPagto.dinheiro;
                        break;

                    case "2": 
                        formaPagto = Enum.FormaPagto.crédito;
                        break;

                    case "3": 
                        formaPagto = Enum.FormaPagto.cashUber;
                        break;
                }

                Corrida corrida1 = new Corrida(passageiro1, origem, destino, formaPagto);
                corrida1.valor = 70;

                Console.WriteLine();
                Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

                Thread.Sleep(8000);

                Console.WriteLine();
                motoristas[0].aceitarCorrida();

                corrida1.motorista = motoristas[0];

                Console.WriteLine();
                corrida1.iniciarCorrida();

                if (corrida1.status != StatusCorrida.statusCorrida.cancelada)
                {
                    Thread.Sleep(8000);

                    Console.WriteLine();
                    corrida1.finalizarCorrida();
                    //corrida1.finalizarCorrida(90);
                }
            }
            else if (opcao == "N")
            {
                Console.WriteLine("Obrigada por acessar o aplicativo - Até a próxima");

            } else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public static void executarSituacao1()
        {
            Console.WriteLine("\n****** Situação 1 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 0);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.crédito);
            corrida1.valor = 150;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[0].aceitarCorrida();

            corrida1.motorista = motoristas[0];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida();

            Console.WriteLine("************************");
        }

        public static void executarSituacao2()
        {
            Console.WriteLine("\n****** Situação 2 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 0);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.crédito);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[1].aceitarCorrida();

            corrida1.motorista = motoristas[1];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida(75);

            Console.WriteLine("************************");
        }

        public static void executarSituacao3()
        {
            Console.WriteLine("\n****** Situação 3 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 100);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.cashUber);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[2].aceitarCorrida();

            corrida1.motorista = motoristas[2];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida();

            Console.WriteLine("************************");
        }

        public static void executarSituacao4()
        {
            Console.WriteLine("\n****** Situação 4 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 100);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.cashUber);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[4].aceitarCorrida();

            corrida1.motorista = motoristas[4];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida(90);

            Console.WriteLine("************************");
        }

        public static void executarSituacao5()
        {
            Console.WriteLine("\n****** Situação 5 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 100);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.cashUber);
            corrida1.valor = 160;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[4].aceitarCorrida();

            corrida1.motorista = motoristas[4];

            corrida1.iniciarCorrida();

            Console.WriteLine("************************");
        }

        public static void executarSituacao6()
        {
            Console.WriteLine("\n****** Situação 6 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 100);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.cashUber);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[4].aceitarCorrida();

            corrida1.motorista = motoristas[4];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida(120);

            Console.WriteLine("************************");
        }

        public static void executarSituacao7()
        {
            Console.WriteLine("\n****** Situação 7 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 0);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.dinheiro);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[4].aceitarCorrida();

            corrida1.motorista = motoristas[4];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida();

            Console.WriteLine("************************");
        }

        public static void executarSituacao8()
        {
            Console.WriteLine("\n****** Situação 8 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 0);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.dinheiro);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            motoristas[4].aceitarCorrida();

            corrida1.motorista = motoristas[4];

            corrida1.iniciarCorrida();

            corrida1.finalizarCorrida(80);

            Console.WriteLine("************************");
        }

        public static void executarSituacao9()
        {
            Console.WriteLine("\n****** Situação 9 ******");

            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Roberto", "1198574-6352", "roberto@gmail.com", "159", 0);

            Endereco origem = new Endereco("Rua Imigrantes", "124", "Vila da Rosas", "São Paulo", "SP", "01452-582");
            Endereco destino = new Endereco("Av. Paulista", "1596", "Paraíso", "São Paulo", "SP", "02563-856");

            passageiro1.solicitarCorrida(origem, destino);

            Corrida corrida1 = new Corrida(passageiro1, origem, destino, Enum.FormaPagto.dinheiro);
            corrida1.valor = 60;

            Console.WriteLine($"A corrida terá o valor de R$ {corrida1.valor} - aguarde um motorista aceitar sua corrida");

            passageiro1.cancelarCorrida();
            corrida1.cancelarCorrida();

            Console.WriteLine("************************");
        }

    }
}
