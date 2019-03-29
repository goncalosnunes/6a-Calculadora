using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Definir o valor inicial das variáveis
            ViewBag.Resposta = "0";
            Session["LimpaEcra"] = true;
            Session["Operador"] = "";

            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(String visor, string btn)
        {

            switch (btn)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (visor == "0" || (bool)Session["LimpaEcra"])
                    {
                        visor = btn;
                        Session["LimpaEcra"] = false;
                    }
                    else
                    {
                        visor += btn;
                    }
                    break;
                // Selecionei o ','

                // selecionei um símbolo de operação: +, -, *, :

                case "+":
                case "-":
                case "x":
                case ":":

                    // já se pressionou, alguma vez, um sinal de operador
                    if ((string)Session["Operador"] == "")
                    {
                        // É a primeira vez que se carregou num operador
                        // guardar operador
                        Session["Operador"] = btn;
                        // guardar o primeiro
                        Session["PrimeiroOperando"] = visor;
                        // marcar a calculadora (leia-se, o VISOR) para ser reiniciada
                        Session["LimpaEcra"] = true;
                    }
                    else
                    {
                        // já há 2 operandos e 1 operador
                        // já se pode executar a operação aritmética
                        // recuperar os dados da operação aritmética
                        double operando1 = Convert.ToDouble(Session["PrimeiroOperando"]);
                        double operando2 = Convert.ToDouble(visor);
                        String operador = (string)Session["Operador"];

                        // agora já posso fazer a operação
                        switch (operador)
                        {
                            case "+":
                                visor = operando1 + operando2 + "";
                                break;
                            case "-":
                                visor = operando1 - operando2 + "";
                                break;
                            case ":":
                                visor = operando1 / operando2 + "";
                                break;
                            case "x":
                                visor = operando1 * operando2 + "";
                                break;
                        }
                        // fim da operação aritmética

                        // preparar a calculadora para continuar as operações
                        // guardar operador
                        Session["Operador"] = btn;
                        // guardar o primeiro
                        Session["PrimeiroOperando"] = visor;
                        // marcar a calculadora (leia-se, o VISOR) para ser reiniciada
                        Session["LimpaEcra"] = true;
                    }// Fecha ELSE
                    break;

                case "=":
                    // já se pressionou, alguma vez, um sinal de operador
                    if ((string)Session["Operador"] == "")
                    {
                        // É a primeira vez que se carregou num operador
                        // guardar operador
                        Session["Operador"] = btn;
                        // guardar o primeiro
                        Session["PrimeiroOperando"] = visor;
                        // marcar a calculadora (leia-se, o VISOR) para ser reiniciada
                        Session["LimpaEcra"] = true;
                    }
                    else
                    {
                        // já há 2 operandos e 1 operador
                        // já se pode executar a operação aritmética
                        // recuperar os dados da operação aritmética
                        double operando1 = Convert.ToDouble(Session["PrimeiroOperando"]);
                        double operando2 = Convert.ToDouble(visor);
                        String operador = (string)Session["Operador"];

                        // agora já posso fazer a operação
                        switch (operador)
                        {
                            case "+":
                                visor = operando1 + operando2 + "";
                                break;
                            case "-":
                                visor = operando1 - operando2 + "";
                                break;
                            case ":":
                                visor = operando1 / operando2 + "";
                                break;
                            case "x":
                                visor = operando1 * operando2 + "";
                                break;
                        }

                        // Resetar calculadora

                        // É a primeira vez que se carregou num operador
                        // guardar operador
                        Session["Operador"] = "";
                        // guardar o primeiro
                        Session["PrimeiroOperando"] = "";
                        // marcar a calculadora (leia-se, o VISOR) para ser reiniciada
                        Session["LimpaEcra"] = true;
                    }
                    
                    break;
                case "C":

                    // Resetar calculadora

                    // É a primeira vez que se carregou num operador
                    // guardar operador
                    Session["Operador"] = "";
                    // guardar o primeiro
                    Session["PrimeiroOperando"] = "";
                    // marcar a calculadora (leia-se, o VISOR) para ser reiniciada
                    Session["LimpaEcra"] = true;
                    visor = "0";
                    break;
                case "+/-":
                    visor = Convert.ToDouble(visor) * (-1) + "";

                    break;
            }
            ViewBag.Resposta = visor;
            return View();
        }
    }
}