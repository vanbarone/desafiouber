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
            string opcao;
            string origem;
            string destino;
            
            alterarCorFonte();

            instanciarMotoristas();

            //motorista 3 fica indisponivel
            motoristas[3].alterarStatus(StatusMotorista.statusMotorista.indisponível, false);

            //
            imprimirCabecalho();

            //instancia passageiro
            Passageiro passageiro1 = new Passageiro("145.789.456-25", "Vanessa", "1198574-6352", "roberto@gmail.com", "159", 150);

            Console.WriteLine($"\nOlá {passageiro1.nome}, deseja realizar uma corrida ? (Digite 'S' ou 'N')");

            opcao = Console.ReadLine().ToUpper().Trim();
            if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

            if (opcao == "S")
            {
                //endereço de origem
                //verifica se quer utilizar a localização atual como endereço de origem, caso queira o programa seta o endereço automaticamente 
                Console.WriteLine("\nSua localização atual será o endereço de origem ? (Digite 'S' ou 'N')");

                opcao = Console.ReadLine().ToUpper().Trim();
                if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

                if (opcao == "S")
                {
                    origem = "Rua Imigrantes, 124 - Vila da Rosas - São Paulo/SP - 01452-582";
                }
                else
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor informe o endereço de origem");
                        origem = Console.ReadLine().Trim();
                    } while (origem == "");
                }

                //endereço de destino
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor informe o endereço de destino");
                    destino = Console.ReadLine().Trim();
                } while (destino == "");


                Corrida corrida1 = new Corrida(passageiro1, origem, destino);

                //Informa o valor da corrida e pergunta se deseja prosseguir
                Console.WriteLine($"\nA corrida terá o valor de R$ {corrida1.valor} - Deseja prosseguir ? (Digite 'S' ou 'N')");
                opcao = Console.ReadLine().ToUpper().Trim();

                if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

                if (opcao == "N")
                {
                    passageiro1.cancelarCorrida();
                }
                else
                {
                    //forma de pagamento
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Qual será a forma de Pagamento ? \n" +
                                        $"   1 - {FormaPagamento.FormaPagto.dinheiro} \n" +
                                        $"   2 - {FormaPagamento.FormaPagto.crédito} \n" +
                                        $"   3 - {FormaPagamento.FormaPagto.cashUber}");

                        opcao = Console.ReadLine().Trim();

                        switch (opcao)
                        {
                            case "1":
                                corrida1.formaPagto = FormaPagamento.FormaPagto.dinheiro;
                                break;

                            case "2":
                                corrida1.formaPagto = FormaPagamento.FormaPagto.crédito;
                                break;

                            case "3":
                                corrida1.formaPagto = FormaPagamento.FormaPagto.cashUber;

                                if (passageiro1.saldo < corrida1.valor)
                                {
                                    Console.WriteLine("\nSeu saldo Uber é insuficiente para pagar essa corrida.\n" +
                                                      "Deseja informar outra forma de pagamento ? (Digite 'S' ou 'N')");
                                    opcao = Console.ReadLine().ToUpper().Trim();

                                    if (opcao == "N")
                                    {
                                        corrida1.cancelarCorrida();
                                        passageiro1.cancelarCorrida();
                                    }
                                    else
                                    {
                                        opcao = "";
                                    }
                                }

                                break;

                            default:
                                opcao = "";
                                Console.WriteLine("Forma de pagamento inválida");
                                break;
                        }
                    } while (opcao == "");

                    if (corrida1.status != StatusCorrida.statusCorrida.cancelada)
                    {
                        alterarCorFundo(false);

                        Console.WriteLine();
                        Console.WriteLine("\tMOTORISTAS NA ÁREA =>\n");
                        mostrarMotoristas(StatusMotorista.statusMotorista.disponível);

                        alterarCorFundo();

                        Console.WriteLine("\nPor favor aguarde um motorista aceitar sua corrida");

                        Thread.Sleep(3000);

                        //Procurando motorista
                        for (int i = 0; i < motoristas.Length; i++)
                        {
                            if (motoristas[i].status == StatusMotorista.statusMotorista.disponível)
                            {
                                if (motoristas[i].aceitarCorrida(origem, destino, corrida1.formaPagto))
                                {
                                    corrida1.motorista = motoristas[i];
                                    break;
                                }
                            }
                        }

                        if (corrida1.motorista == null)
                        {
                            Console.WriteLine("\nInfelizmente no momento nenhum motorista pôde aceitar essa corrida - Tente mais tarde");
                        }
                        else
                        {
                            corrida1.iniciarCorrida();

                            Console.WriteLine();

                            for (int i = 0; i <= 6; i++)
                            {
                                Console.Write("^ ...\t");
                                Thread.Sleep(3000);
                            }

                            Console.WriteLine();

                            corrida1.finalizarCorrida();

                            if (corrida1.formaPagto != FormaPagamento.FormaPagto.dinheiro)
                            {
                                alterarCorFonte(false);

                                Console.WriteLine("\nA corrida teve um acréscimo de valor ? (Digite 'S' ou 'N')");

                                opcao = Console.ReadLine().ToUpper().Trim();
                                if (opcao.Length > 1) opcao = opcao.Substring(0, 1);

                                alterarCorFonte();

                                if (opcao == "S")
                                {
                                    corrida1.cobrarCorrida(90);
                                }
                            }

                            Console.WriteLine("\nObrigada por utilizar nosso aplicativo - Até a próxima");
                        }
                    }
                }
            }
            else if (opcao == "N")
            {
                Console.WriteLine("\nObrigada por acessar nosso aplicativo - Até a próxima");

            }
            else
            {
                Console.WriteLine("\nOpção inválida");
            }

            //Volta as cores padrões do console
            Console.ResetColor();
        }


        public static void instanciarMotoristas()
        {
            // cria instancia de 5 motoristas

            motoristas[0] = new Motorista();
            motoristas[0].cpf = "120.909.698-65";
            motoristas[0].nome = "Geovani";
            motoristas[0].celular = "1196162-9596";
            motoristas[0].email = "fernando@gmail.com";
            motoristas[0].senha = "123";
            motoristas[0].carro = new Carro("Chevrolet", "Cruze", "ABC1234", "Preto");

            //
            motoristas[1] = (new Motorista("148.953.847-85", "Eduardo", "1198485-6936", "henrique@gmail.com", "785", new Carro("Honda", "Fit", "ERF7859", "Branco")));
            motoristas[2] = (new Motorista("125.485.962-00", "Juliana", "1196385-4825", "ana@gmail.com", "369", new Carro("Citroen", "C4", "FRD4856", "Vermelho")));
            motoristas[3] = (new Motorista("196.785.486-65", "Marcelo", "1192233-8855", "caique@gmail.com", "245", new Carro("Toyota", "Corolla", "CDC1526", "Azul")));
            motoristas[4] = (new Motorista("111.222.333-85", "Adriano", "1198855-4763", "joana@gmail.com", "796", new Carro("Volkswagen", "Gol", "PLN4856", "Cinza")));
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

        public static void alterarCorFonte(bool corPadrao = true)
        {
            Console.ForegroundColor = (corPadrao ? ConsoleColor.Yellow: ConsoleColor.Blue);
        }

        public static void alterarCorFundo(bool corPadrao = true)
        {
            Console.BackgroundColor = (corPadrao ? ConsoleColor.Black : ConsoleColor.Yellow);
            Console.ForegroundColor = (corPadrao ? ConsoleColor.Yellow : ConsoleColor.Black);
        }

        public static void imprimirCabecalho()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Bem vindo ao aplicativo Uber");
            Console.WriteLine("-----------------------------------------------------");
        }

    }
}
