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
            dynamic sg = new SendGrid.SendGridAPIClient("apiKey");
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
                'template_id': 'd6f62767-04ae-48fd-ac2a-1b0d32774e3d',     
            }";

            Object json = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            dynamic response = await sg.client.mail.send.post(requestBody: json.ToString());
        }
        public static async Task ExecuteChangePassword(string toEmail, string callbackUrl)
        {
            dynamic sg = new SendGrid.SendGridAPIClient("apikey");
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
                'template_id': 'd6f62767-04ae-48fd-ac2a-1b0d32774e3d',     
            }";

            Object json = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(data);
            dynamic response = await sg.client.mail.send.post(requestBody: json.ToString());
        }
    }
}
