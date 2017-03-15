using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleSignonAuth.Managers
{
    public class SendgridManager
    {
        public static async Task ExecuteEmailConfirmation(string toEmail, string callbackUrl)
        {
            dynamic sg = new SendGridAPIClient(ConfigurationManager.AppSettings["sendGridApiKey"]);
            string data = @"{
              'personalizations':
                [
                    {
                        'to': 
                        [
                            {
                              'email': '" + toEmail + @"'
                            }
                        ],
                        'substitutions':
                        {
                            '-name-': 'Example User',
                            '-city-': 'Denver'
                        },
                        'subject': 'I\'m replacing the subject tag'
                    }
              ],
              'from':
                {
                    'email': '" + ConfigurationManager.AppSettings["fromEmailId"] + @"'
                },
              'content': 
                [
                    {
                      'type': 'text/html',
                      'value': 'Please click <a href=""" + callbackUrl + @""">here</a> for Email Confirmation'
                    }
                ],      
                'template_id': '" + ConfigurationManager.AppSettings["templateIdForEmailConfirmation"] + @"',     
            }";

            Object json = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            dynamic response = await sg.client.mail.send.post(requestBody: json.ToString());
        }
        public static async Task ExecuteForgetPassword(string toEmail, string callbackUrl)
        {
            dynamic sg = new SendGridAPIClient(ConfigurationManager.AppSettings["sendGridApiKey"]);
            string data = @"{
              'personalizations':
                [
                    {
                        'to': 
                        [
                            {
                              'email': '" + toEmail + @"'
                            }
                        ],
                        'substitutions':
                        {
                            '-name-': 'Example User',
                            '-city-': 'Denver'
                        },
                        'subject': 'I\'m replacing the subject tag'
                    }
              ],
              'from':
                {
                    'email': '" + ConfigurationManager.AppSettings["fromEmailId"] + @"'
                },
              'content': 
                [
                    {
                      'type': 'text/html',
                      'value': 'Please click <a href=""" + callbackUrl + @""">here</a> for Changing Password'
                    }
                ],      
                'template_id': '" + ConfigurationManager.AppSettings["templateIdForForgetPassword"] + @"',     
            }";

            Object json = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            dynamic response = await sg.client.mail.send.post(requestBody: json.ToString());
        }
    }
}
