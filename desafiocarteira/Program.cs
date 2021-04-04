using System;
using System.Collections.Generic;

namespace desafiocarteira
{   
    
    class Program
    {
        static void Main (string[] args)
        {
            
            Dictionary <string,int> Carteira = new Dictionary <string,int>(); //Criando um dicionário - Carteira
            List<string> Extrato = new List<string>(); //Criando uma lista - Extrato
            Console.WriteLine("Vamos começar? Digite seu nome:"); //Imprimindo mensagem pedindo o nome
            string NomeCliente = Console.ReadLine(); //Lendo o nome do cliente
            Console.Clear(); //Limpando a tela
            Console.WriteLine("\nBem-vindo(a) à sua carteira de invertimentos, "+NomeCliente+"!\nComo podemos ajudar?\n"); //Imprimindo mensagem para o cliente com o nome
            string Resposta; 
            string NomeAtivo;
            int valortotal;
            int soma = 0;
            
            while (true) {
                Console.WriteLine(new String('-', 40)+"\n"+new String(' ', 13)+"MENU PRINCIPAL\n"+new String('-', 40)); //Imprimindo Menu Principal
                Console.WriteLine("\nDigite a opção que deseja realizar:\n 1- Adicionar um novo ativo na carteira.\n 2- Visualizar a lista de ativos investidos.\n 3- Informar a venda de um ativo.\n 4- Visualizar resumo do valor total investidos.\n 5- Sair"); //Imprimindo opções
                int menu;
                while (!(int.TryParse(Console.ReadLine(), out menu))) Console.WriteLine("\nOpção não numerica, digite novamente: "); //Lendo uma opção não númerica
                
                switch (menu) {

                    // A opção 1 é para adicionar um novo ativo na carteira
                    case 1: 
                    Console.Clear();
                    Console.WriteLine("\n"+NomeCliente+", você selecinou a opção: Adicionar um novo ativo na carteira.\nDigite o ativo que deseja adicionar na sua carteira ou digite 1 se desejar voltar ao menu principal."); //Pedindo para o cliente colocar um ativo ou se desejar voltar ao menu
                    Resposta = Console.ReadLine();
                    if (Resposta=="1"){ //Voltar ao menu
                        Console.Clear(); 
                    }
                    
                    else{ //Adicionando um ativo
                        Console.Clear();
                        NomeAtivo = Resposta;
                        NomeAtivo = NomeAtivo.ToUpper(); //Transformando todas as letras em maiusculas
                        Console.WriteLine("Digite a quantidade:");
                        int quantidade = int.Parse(Console.ReadLine()); //Lendo a quantidade (inteiro)
                        Console.Clear();
                        Console.WriteLine("Digite o valor de cada unidade:");
                        int ValorUnidade = int.Parse(Console.ReadLine()); //Lendo o valor unitário (inteiro)
                        DateTime dataEntrada = DateTime.Now; //Guardando a data e hora que esse ativo foi adicionado
                        soma = soma+quantidade; //Soma servirá para imprimir o total na carteira
                        if(Carteira.ContainsKey(NomeAtivo)){ //Se possui já esse ativo na carteira
                            
                           Carteira[NomeAtivo] = Carteira[NomeAtivo] + quantidade; //Somando a quantidade com o ativo que já tinha na carteira
                           

                        }else{ //Se o ativo for novo
                            Carteira.Add(NomeAtivo, quantidade); //Guardando no dicionário o nome do ativo e sua quantidade
                        }
                        valortotal = quantidade * ValorUnidade; //Calculando o valor total
                        Extrato.Add(dataEntrada + "\tAdicionado\t" + NomeAtivo + "\t" + quantidade + "\t\t" + ValorUnidade + "\t\t\t" + valortotal); //Adicionando na lista extrato a data e hora do ativo, seu nome, quantidade, valor da unidade e valor total


                        Console.WriteLine("\nVocê adicionou " + quantidade + " unidades do ativo " + NomeAtivo + " com sucesso!"); //Mensagem de sucesso
                        Console.WriteLine("\nDigite 1 para voltar ao menu principal."); //Voltar ao menu
                        Resposta = Console.ReadLine();

                        if (Resposta=="1"){
                            Console.Clear();
                        }
                        else{

                        }
                    }
                   
                    break;
                    
                    //Opção 2 é para visualizar o extrato
                    case 2: 
                    Console.Clear();
                    Console.WriteLine("\n"+NomeCliente+", você selecinou a opção: Visualizar a lista de ativos investidos.\n Essa é sua lista de ativos investidos:\n"); //Mensagem para o cliente
                    
                    Console.WriteLine("Data\t   Hora\t\tEstado\t\tCódigo\tQuantidade\tValor Unidade\t\tValor Total"); //Nome das colunas

                    foreach(string c in Extrato){ //Imprimindo a lista
                        Console.WriteLine("{0}",c);
                        
                    }

                    Console.WriteLine("\nDigite 1 para voltar ao menu principal."); //Para voltar ao menu
                    Resposta = Console.ReadLine();
                    if (Resposta=="1"){
                        Console.Clear();
                    }
                   
                    else{
                        
                    }
                    break;
                    
                    //Opção 3 é para informar a venda de um ativo
                    case 3: 
                        Console.Clear();
                        Console.WriteLine("\n"+NomeCliente+", você selecinou a opção: Informar a venda de um ativo.\nDigite o nome do ativo que vendeu ou digite 1 se desejar voltar ao menu principal."); //Digitar o nome do ativo ou se desejar voltar ao menu
                        Resposta = Console.ReadLine();
                        
                        if (Resposta=="1"){ //Voltar ao menu
                            Console.Clear();
                        }
                    
                        else{
                            Console.Clear();
                            NomeAtivo = Resposta;
                            NomeAtivo = NomeAtivo.ToUpper(); //Colocando o nome do ativo em maiuscula
                            
                            if(Carteira.ContainsKey(NomeAtivo)){ //Se esse ativo estiver na carteira
                                
                                Console.WriteLine("\nDigite a quantidade vendida:");
                                int ativoqntvendido = int.Parse(Console.ReadLine()); //Lendo a quantidade que foi vendida

                                if(Carteira[NomeAtivo] >= ativoqntvendido){ //Verificando se o cliente tem quantidades suficientes para vender
                                    Console.Clear();
                                    Console.WriteLine("\nDigite o valor de cada unidade vendida:");
                                    int ValorUnidade = int.Parse(Console.ReadLine()); //Lendo o valor de cada unidade

                                    Carteira[NomeAtivo] = Carteira[NomeAtivo] - ativoqntvendido; //Diminuindo a quantidade daquele ativo vendido
                                    valortotal = ativoqntvendido * ValorUnidade; //Calculando o valor total
                                    DateTime dataEntrada = DateTime.Now; //Guardando a data e hora que o ativo foi vendido
                                    
                                    
                                    Extrato.Add(dataEntrada + "\tVendido\t\t" + NomeAtivo + "\t" + ativoqntvendido + "\t\t" + ValorUnidade + "\t\t\t" + valortotal); //Guardando todas as informações no extrato

                                    soma = soma-ativoqntvendido; //Soma servirá para imprimir o total na carteira, diminuindo a quantidade vendida
                                    if(Carteira[NomeAtivo] == 0){ //Se a quantidade desse ativo for 0 depois da venda, retirar esse ativo da carteira para não ocupar memória
                                        Carteira.Remove(NomeAtivo);
                                    }
                                
                                
                                    Console.WriteLine("\nAtivo vendido com sucesso!\nDigite 1 para voltar ao menu principal."); //Mensagem de sucesso
                                    
                                    Resposta = Console.ReadLine();
                                    if (Resposta=="1"){
                                        Console.Clear();
                                    }
                                    
                                }else{
                                    Console.WriteLine("\nVocê não possui quantidade suficiente desse ativo para vender."); //Se a quantidade de ativos na carteira for menor a quantidade de ativos que o cliente deseja vender
                                    break;
                                }

                            }else{
                                Console.WriteLine("\nVocê não possui esse ativo na carteira, tente novamente."); //Se o cliente não possuir o ativo na carteira para venda
                                break;
                            }
                        }
                    break;

                    //Opção 4 é para visualizar o resumo dos ativos na carteira
                    case 4: 
                    Console.Clear();
                    Console.WriteLine("\n"+NomeCliente+", você selecinou a opção: Visualizar resumo do valor total investidos.\n"); //Mensagem ao cliente
                    Console.WriteLine("\nAtivo\tQuantidade"); //Titulos das colunas
                    
                    foreach(KeyValuePair<string, int> v in Carteira){ //Imprimindo o dicionário Carteira
                        Console.WriteLine(v.Key + "\t" + v.Value); //Imprimindo as chaves e valores
                    }
                    
                    
                    Console.WriteLine("\nTotal = " + soma); //Imprimindo o total de ativos que o cliente tem na carteira (contando todos os ativos juntos)
                    Console.WriteLine("\nDigite 1 para voltar ao menu principal"); //Para voltar ao Menu
                    Resposta = Console.ReadLine();
                    if (Resposta=="1"){
                       Console.Clear();
                    }
                    
                    else {

                    }
                    break;

                    //Opção 5 é para sair da aplicação
                    case 5:
                    Console.WriteLine("\nObrigado por usar nossa carteira, até breve!"); //Mensagem de Adeus 
                    Environment.Exit(0); //Comando para encerrar
                    
                    break;

                    default: //Caso a opção escolhida pela cliente for uma opção númerica não apresentada
                    Console.Clear();
                    Console.WriteLine("Nós não temos esta opção, escolha novamente:"); break; //Mensagem de erro
                }
            } 
            

        } 
        
        
    }
}
