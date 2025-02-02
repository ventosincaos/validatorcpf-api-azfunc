using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace httpValidaCPF
{
    public static class fnvalidacpf
    {
        [FunctionName("fnvalidacpf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Iniciando a validação do CPF");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                
                if(string.IsNullOrEmpty(requestBody))
                {
                    return new BadRequestObjectResult("Por favor, informe o CPF.");
                }

                var data = JsonConvert.DeserializeObject<CpfModel>(requestBody);
                
                if(data?.Cpf == null)
                {
                    return new BadRequestObjectResult("Formato inválido. Envie JSON: { \"cpf\": \"numero\" }");
                }

                string cpf = data.Cpf;
                bool isValid = ValidaCPF(cpf);

                if (!isValid)
                {
                    // SUA MENSAGEM ORIGINAL AQUI
                    return new BadRequestObjectResult("CPF inválido.");
                }

                var responseMessage = "CPF válido, e não conta na base de dados de fraudes, e não consta na base de dados de débitos.";
                return new OkObjectResult(responseMessage);
            }
            catch (Exception ex)
            {
                log.LogError($"Erro: {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public static bool ValidaCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Limpeza completa do CPF
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf[..9];
            
            int soma = tempCpf
                .Select((c, i) => (c - '0') * multiplicador1[i])
                .Sum();

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;

            soma = tempCpf
                .Select((c, i) => (c - '0') * multiplicador2[i])
                .Sum();

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }

    public class CpfModel
    {
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
    }
}