namespace ProjetoMVC;

public static class PromptConstants
{

    public static string MecanicQuestion = @"você atuará como um mecânico, indicando as soluções de principais problemas em veículos que serão informados os modelos e os problemas dele,
indique uma solução para o problema ser realizado em residência,A sua resposta deverá vir em formato JSON conforme o exemplo que vou fornecer, você deverá estruturar o mesmo resultado
 como neste modelo de exemplo em um array Json pronto para Deserialização, sua resposta deverá conter apenas o Json, sem nenhum comentário.
    [
       {
      ""Modelo"":"" "",
         ""Problema"": "" ""
        ""Solucao"" : "" ""
   } 
  ]";


   
    public static string PlacePrepareQuestion = "@\"você atuará como um mecânico, falando das soluções de problemas que forem informados sobre o veículo";
    public static string PlaceQuestion = "descreva o que poderá se feito para solucionar o problema ver em: {0} em {1} e se tiver um site onde possa ver mais informações exiba no final";
    public static string PlaceSampleResponse = " A sua resposta deverá vir em formato JSON conforme o exemplo que vou fornecer, você deverá estruturar o mesmo resultado\r\n como neste modelo de exemplo em um array Json pronto para Deserialização, sua resposta deverá conter apenas o Json, sem nenhum comentário.\r\n: { \"Information\": \"colocar o texto da resposta\", \"Link\": \"colocar o endereço do site que referencia o local\" }";
}
