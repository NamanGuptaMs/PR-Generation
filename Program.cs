namespace DemoProject_IntelligentAssist
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    class Program
    {
        public static async void createPR()
        {
            try
            {
                var personalaccesstoken = "PAT_TOKEN";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    string getBranchid_url = "https://dev.azure.com/O365Exchange/O365%20Core/_apis/git/repositories/bf3ac165-37ff-4c93-b0e0-1b0498f8269c/refs?filter=heads/u/namagupta/IA_ISRAEL_Buildout&api-version=5.1";
                    string israelRepo_id = "b5fdea36e5bb99c9697d7e459d537e7894155147";     // this gets updated after every commit, fetch the new id everytime

                    string pullReq_id = "2921642";

                    string repoUrl = "https://dev.azure.com/O365Exchange/O365%20Core/_apis/git/repositories/bf3ac165-37ff-4c93-b0e0-1b0498f8269c/pushes?api-version=5.1";

                    string commentURL = "https://dev.azure.com/O365Exchange/O365%20Core/_apis/git/repositories/bf3ac165-37ff-4c93-b0e0-1b0498f8269c/pullRequests/2921642/threads?api-version=7.0";

                    string change1 = "{ \"changeType\": \"edit\", \"item\": { \"path\": \"/ServiceModelResourcesSetup_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ServiceModelFiles\ServiceModelResourcesSetup_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    /*string change2 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/RolloutSpecResourcesSetup_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\RolloutSpecFiles\RolloutSpecResourcesSetup_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change3 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/RolloutSpec_GraphContentSetup_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\RolloutSpecFiles\RolloutSpec_GraphContentSetup_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change4 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/PrivacyCosmosDb.ISR.Parameters.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ParameterFiles\PrivacyCosmosDb.ISR.Parameters.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change5 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/ServiceModel_GraphContentSetup_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ServiceModelFiles\ServiceModel_GraphContentSetup_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change6 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/DSRQueue.ISR.Parameters.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ParameterFiles\DSRQueue.ISR.Parameters.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }";
                    string change7 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/ServiceModelInsightsAppSetup_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ServiceModelFiles\ServiceModelInsightsAppSetup_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change8 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/RolloutSpecInsightsAppSetup_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\RolloutSpecFiles\RolloutSpecInsightsAppSetup_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change9 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/RolloutSpec_PrivacyUserSync_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\RolloutSpecFiles\RolloutSpec_PrivacyUserSync_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change10 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/PrivacyARMService.Parameters.ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ParameterFiles\PrivacyARMService.Parameters.ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change11 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/ServiceModel_PrivacyUserSync_ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ServiceModelFiles\ServiceModel_PrivacyUserSync_ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    string change12 = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/PrivacyARMServiceSetup.Parameters.ISR.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\ParameterFiles\PrivacyARMServiceSetup.Parameters.ISR.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }";
                    */
                    // string template_change = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/RAEnvProd-spoactivityprodrg_EHNAMESPACES_TargetNameSpace.Template.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\SPO_Config\RAEnvProd-spoactivityprodrg_EHNAMESPACES_TargetNameSpace.Template.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }, ";
                    // string scopeBinding_change = "{ \"changeType\": \"add\", \"item\": { \"path\": \"/RAEnvProd.ScopeBindings.json\" }, \"newContent\": { \"content\": \"" + File.ReadAllText(@"C:\Users\namagupta\source\repos\GenerateJson\GenerateJson\bin\Debug\SPO_Config\RAEnvProd.ScopeBindings.json").Replace("\"", "\\\"") + "\", \"contentType\": \"rawtext\" } }";

                    var requestBody = "{ \"refUpdates\": [{ \"name\": \"refs/heads/u/namagupta/IA_ISRAEL_Buildout\", \"oldObjectId\": \"b9d3a23246a67612f08b02a0f2dc9273a3dc5d6e\" }], \"commits\": [{ \"comment\": \"Artifacts for Israel\", \"changes\": [" + change1 + "] }] }";

                    var newRequstBody = "{ \"refUpdates\": [{ \"name\": \"refs/heads/u/namagupta/IA_ISRAEL_Buildout\", \"oldObjectId\": \"" + israelRepo_id + "\" }], \"commits\": [{ \"comment\": \"New changes pushed\", \"changes\": [" + change1 + "] }] }";

                    var commentRequestBody = "{ \"comments\": [{ \"content\": \"```suggestion\nTrue\n```\", \"commentType\": 1 }], \"status\": 1, \"threadContext\": {\"filePath\": \"/DSRQueue.ISR.Parameters.json\", \"rightFileEnd\": { \"line\": 18, \"offset\": 35 }, \"rightFileStart\": {\"line\": 18, \"offset\": 23 } }, \"pullRequestThreadContext\": { \"changeTrackingId\": 1, \"iterationContext\": { \"firstComparingIteration\": 1, \"secondComparingIteration\": 2 } } }";

                    var content = new StringContent(commentRequestBody, Encoding.UTF8, "application/json");

                    // using (HttpResponseMessage response = client.GetAsync(getBranchid_url).Result)
                    using (HttpResponseMessage response = client.PostAsync(commentURL, content).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(response.StatusCode);
                        Console.WriteLine(response.Content);
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            createPR();
            Console.ReadLine();
        }
    }
}
