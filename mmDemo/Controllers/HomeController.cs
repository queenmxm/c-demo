using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mmDemo.Models;
using Aop.Api.Domain;
using NLog;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using Aop.Api.Util;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;

namespace mmDemo.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

        public JsonResult mm()
        {
            string URL = "https://openapi.alipaydev.com/gateway.do";
            string APPID = "2016101200670534";
            string APP_PRIVATE_KEY = "MIIEowIBAAKCAQEAmntOV0IUH9GIA24Z3uFMm32b5awGqZhmtygEwg6G8BI4pbREjgzG0O9450eEK+7mk6gAImqA9GZ5BysnlKZtzDvShs6mircE45tlZVVBi2IH/6vbmUkl33MLPIF0OoCZWiQ9FqDJD7cEcssY+43yTMokwpJ7p3GzBDMBfSjJ6lELCHv7C2TkfuB9PuntczDL6qeOVSqPSuomyjpdFdgDMfpCxou2yaevF0GA+Z8CMXoHTfVNGmwKllPkqk1SJjwuPckMmHiZaVK1T11Lbxusp+RYVqDqSYlQ95tcPJZvJRZmA1a/r6CqkOjpKj7UN1BMKQSOW3zG1Loru0/EagIfWwIDAQABAoIBACs8ze2AUi+hrsb+/wCx4IY4vvSmlGrNfBpRehtyg3QYNYCzluiHTPJXxGg/TRAa2rCDOh5n3tYJBGDsRDTH7D1YlREkL9rtZNHrwZJ+LU08z+5QhLM/lPkYsxFpTkW9jq57LBn0QLJEUFts2v41eZbikS1gYHm6Shenywfj7bfGLcOoQpdsqDjdl3nvEqUxfnhEmtXm9VGugmqi55d7PmSQlprYoTU9EWgUoustBqLD/9xTfylh8PcjR6ogtRYNzasWfCGA4qFh1MvJ/b48RpRVA1a6wgbVIOP5hBGShzkBoNXsBw7KkmfL02xd7QqKK6/mBZ/TXA6HS1eZU4icr7ECgYEAzfDyYJREAe8VVRmoWw5jVcu2v7bJZu6/zWEamgtKENGn2HG3rAc++H5qVcEqr9H0aJJ2uEtnr4W/RebfQLc/tyZ5osEO5De2gwPFQe9CV1SEeU11wgxz1mviFfLzQSQiwdWtYTU23qQruYtHvvg2EmlJvIKBV4RR+pKkkv8Ig+kCgYEAwAgzAE8HUnEeysG57DZwGT7CimSv6Ot4i39oYx1Fq0H7M0D6rBiHhQzYMAm+VaRNt2cN0luHAnD5H0DO1oNymFKNbp1axc/eLePxjyfP/8d377sqZJrwDURGn4XZtbFx5FsJDbc51w6GIBzjRfmuU5Es+YqXCPXW/iLeFvi50qMCgYEAxfzlKFCiaTGPUrdOEextN6iX0wxJ6DmUEEFQr9Q2qqDFOuNo72wv7/qpBDSnc0zoKjjVBi0IS8jLsMpay/7gtJW6zuvIA0REpQRU+iSppQfOLEh588rA+t3RB8UAdBnniG6DNzdPvxAaMVFj8obyhRTQHPlim97MaZfdvKyPZTECgYAmCHmxcfWNSoJCviPIuO9y0I9PQanlg92YI1/VYZLO3H6YJCKBu0n7/BNFUGi2JZiO3oZKR35x6VYt7nQI4Hft20vPwLKdwxHKHP9WzxfPHP6QKI2450bsGb2zEpuP9NkN1UnxwXxfL6045v/MeCsiufoiYmSPjcFLDDTYb+K96QKBgANinhyirPECZbv6U5AdBEDH4ZUQWH5zM9Nxbu2/MQBLfqOLvRsbogGVfl7OqfKSrKbBTTetM604qLSs20P6m4pGgxASk9EC6h9k3OUtXD6cgLGUC2ZRjcsJ8ObCuuzpW2ir3KeebX7TAtYr5RQsUBt0hujYdfdSdRJCnfFy+McL";
            string ALIPAY_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnjbWoqaEae/hm62SMN7xeIPVoMjw5EPMzXioq+fEnb/PcsiBijwqpY2Zi1kKcvY/vLe/vR7MTUGL+rlRrsPsYItGT58+tVISEZ3mbWKOnyj+iooQviRf8AyFnUDWP0toxvD5Cc5H7Jjtf02fu4MLrD37cIRJTjywdtkrxfv+R4F2gcXhKN5C6lKKnjNGgc5d6F1RVRZIBAmXZc7tm8QaSB9qzheUrqbsHl0w+n0cNViSFwk8JPCysKdPJNYVXCUz3p9QSji1OWfOOFUacOBXWQDQoabT+mh7Ekl2p7NBTSiop7O50DhTHax8UOj3ju6tkXIkt0e+UXjMPRJmwP8NmwIDAQAB";
            IAopClient client = new DefaultAopClient(URL, APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY,"utf-8", false);
            //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.open.public.template.message.industry.modify 
            
            AlipayOpenPublicTemplateMessageIndustryModifyRequest request = new AlipayOpenPublicTemplateMessageIndustryModifyRequest();
            //SDK已经封装掉了公共参数，这里只需要传入业务参数
            //此次只是参数展示，未进行字符串转义，实际情况下请转义
            request.BizContent = "{" +
            "    \"primary_industry_name\":\"IT科技/IT软件与服务\"," +
            "    \"primary_industry_code\":\"10001/20102\"," +
            "    \"secondary_industry_code\":\"10001/20102\"," +
            "    \"secondary_industry_name\":\"IT科技/IT软件与服务\"" +
            "  }";
            AlipayOpenPublicTemplateMessageIndustryModifyResponse response = client.Execute(request);
            //调用成功，则处理业务逻辑
            if (!response.IsError)
            {
                //.....
                return Json(new { code = 1, msg = "调用成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = 0, msg = "调用失败" }, JsonRequestBehavior.AllowGet);
            }
            
        }
        /// 发起支付请求
        /// </summary>
        /// <param name="tradeno">商家订单号</param>
        /// <param name="subject">订单标题</param>
        /// <param name="totalAmout">付款金额</param>
        /// <param name="itemBody">商品描述</param>
        /// <returns></returns>
        //[HttpPost]
        public void PayRequest(string tradeno, string subject, string totalAmout, string itemBody)
        {
            DefaultAopClient client = new DefaultAopClient(Config.Gatewayurl, Config.AppId, Config.PrivateKey, "json", "2.0",
                Config.SignType, Config.AlipayPublicKey, Config.CharSet, false);

            #region 预交易创建 设置二维码超时时间
            AlipayTradePrecreateModel pModel = new AlipayTradePrecreateModel();
            pModel.OutTradeNo = tradeno;
            pModel.TotalAmount = totalAmout;
            pModel.Subject = subject;
            pModel.TimeoutExpress = "30m";
            AlipayTradePrecreateRequest pRequest = new AlipayTradePrecreateRequest();
            pRequest.SetBizModel(pModel);
            AlipayTradePrecreateResponse pResponse = client.Execute(pRequest);
            //返回二维码链接
            string qrCode = pResponse.QrCode;
            Log.Info("二维码的链接" + qrCode);
            Log.Info("预交易返回值" + pResponse.Body);
            #endregion

            #region 交易支付
            // 组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = itemBody;
            model.Subject = subject;
            model.TotalAmount = totalAmout;
            model.OutTradeNo = tradeno;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";
            
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            //设置同步跳转地址
            request.SetReturnUrl("https://luffy1234.goho.co/Home/SuccessIndex");
            // 设置异步通知接收地址
            request.SetNotifyUrl("https://luffy1234.goho.co/Home/Success");
            // 将业务model载入到request
            request.SetBizModel(model);
            var response = client.SdkExecute(request);
            //cookie测试的
            HttpCookie cookie = new HttpCookie("OutTradeNo");
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Value = tradeno;
            Response.Cookies.Add(cookie);
            //跳转支付宝支付


            Response.Redirect(Config.Gatewayurl + "?" + response.Body);
            #endregion

        }
       

        public void  Success()
        {
            Log.Info("发送成功，异步调用到了该方法");            
            /* 实际验证过程建议商户添加以下校验。
               1、商户需要验证该通知数据中的out_trade_no是否为商户系统中创建的订单号，
               2、判断total_amount是否确实为该订单的实际金额（即商户订单创建时的金额），
               3、校验通知中的seller_id（或者seller_email) 是否为out_trade_no这笔单据的对应的操作方（有的时候，一个商户可能有多个seller_id/seller_email）
               4、验证app_id是否为该商户本身。
               */
            Dictionary<string, string> sArray = GetRequestPost();
            DefaultAopClient client = new DefaultAopClient(Config.Gatewayurl, Config.AppId, Config.PrivateKey, "json", "2.0",
                Config.SignType, Config.AlipayPublicKey, Config.CharSet, false);
            //测试取出cookie
            try
            {
                string OutTradeNo = Request.Cookies["OutTradeNo"].Value.ToString();
                Log.Info("cookie的值为：" + OutTradeNo);
            }
            catch(Exception e)
            {
                Log.Info("cookie发生异常");
            }
            

            if (sArray.Count != 0)
            {
                Log.Info("request有数据");
                bool flag = AlipaySignature.RSACheckV1(sArray, Config.AlipayPublicKey, Config.CharSet, Config.SignType, false);
                if (flag)
                {
                    Log.Info("签名验证成功");
                    //交易状态
                    #region 查询交易状态
                    AlipayTradeQueryModel qModel = new AlipayTradeQueryModel();
                    qModel.OutTradeNo = Request.Form["out_trade_no"];
                    AlipayTradeQueryRequest qRequest = new AlipayTradeQueryRequest();
                    qRequest.SetBizModel(qModel);
                    AlipayTradeQueryResponse qResponse = client.Execute(qRequest);
                    Log.Info("交易状态：" + qResponse.Body);

                    #endregion




                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //请务必判断请求时的total_amount与通知时获取的total_fee为一致的
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                    string trade_status = Request.Form["trade_status"];
                    Response.Write("success");
                }
                else
                {
                    Response.Write("fail");
                    Log.Info("签名验证失败");
                }
            }
            else
            {
                Log.Info("request空数据");
            }


        }

        public Dictionary<string, string> GetRequestPost()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //coll = Request.Form;
            coll = Request.Form;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;
        }

        public ActionResult SuccessIndex()
        {
            return View();
        }

        public void test()
        {
            string str1 = "2019-12-08 09:00:00.000";
            string str2 = "2019-10-27 00:00:00.000";
            DateTime d1 = Convert.ToDateTime(str1);
            DateTime d2 = Convert.ToDateTime(str2);
            int monthB = d1.Month;
            int dayB = d1.Day;

            int monthNow = d2.Month;
            int dayNow = d2.Day;
            if(monthNow>monthB&&dayNow==dayB)
            {

            }
            //DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));
            //DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));
            DateTime c = DateTime.Parse(d1.ToString("yyyy-MM-dd"));
            DateTime d = DateTime.Parse(d2.ToString("yyyy-MM-dd"));
            int days = (d - c).Days;
           int a = (int)System.Data.Entity.DbFunctions.DiffDays(d2,DateTime.Now);


            int newDays = (DateTime.Now - d2).Days;
            Log.Info("应该是0：日期是："+ a);  
        }
        public void main (int value)
        {
            int[] a = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 46, 79 };          
            TestTwo(a,value);
        }

        /// <summary>
        ///  * 二分查找 [L,R]* 
        /// </summary>
        /// <param name="arr">从小到大排好序的 数组 </param>
        /// <param name="value">要从数组中找的目标值 </param>
        public void TestTwo(int[] arr, int value)
        {
            int left = 0;
            int right = arr.Length - 1;
            int middle;
            while (left <= right )
            {
                middle = left + (right - left) / 2; 
                Log.Info("当前的中间值是" + middle);
                if (value > arr[middle])
                {
                    left = middle + 1;
                }
                else if (value < arr[middle])
                {
                    right = middle + 1;
                }
                else
                {
                    Log.Info("在数组下标为" + middle + "找到了该值");                  
                    break;
                }   
            }
        }
        /// <summary>
        /// [L,R)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        public void test2(int[] arr, int value)
        {
            int left = 0;
            int right = arr.Length - 1;
            int middle;
            while (left < right)
            {
                middle = left + (right - left) / 2;
                Log.Info("当前的中间值是" + middle);
                if (value > arr[middle])
                {
                    left = middle + 1;
                }
                else if (value < arr[middle])
                {
                    right = middle + 1;
                }
                else
                {
                    Log.Info("在数组下标为" + middle + "找到了该值");
                    break;
                }
            }
        }

        public async Task<int> Async()
        {
            int i = 0;
            await Task.Run(() => {
                
                for (i = 0; i < 1000; i++)
                {
                    Log.Info("跑线程中》》》》》》》");
                }
                
            });
            return i;
        }

        public async Task<JsonResult> MMAsync()
        {
            int t = await Async();
            int jq = 0; 
            for (int b = 0; b<20; b++)
            {
                Log.Info("其他的逻辑哦");
            }
            for (int i = 0; i < 100; i++)
            {
                t++;
                if (i == 0)
                {
                    Log.Info("开始执行t应该等待的循环方法");
                }
                if (i == 99)
                {
                    Log.Info("t应该等待的循环方法执行结束了end");
                }
            }
            for (int j = 0; j< 99999999; j++)
            {
                if (j == 0)
                {
                    Log.Info("开始执行我们后面的j方法了");
                }
                if (j == 99999998)
                {
                    Log.Info("后面的j方法结束了end");
                }
            }
            return Json(new { code = 0, data = t ,jq}, JsonRequestBehavior.AllowGet);
        }

        public int Async1()
        {
            int i = 0;
            Task.Run(() => {

                for (i = 0; i < 20; i++)
                {
                    Log.Info("跑线程中》》》》》》》");
                }

            });
            return i;
        }

        public  JsonResult MMAsync1()
        {
            int t = Async1();
            int jq = 0;
            for (int i = 0; i < 100; i++)
            {
                t++;
                if (i==0)
                {
                    Log.Info("开始执行t应该等待的循环方法");
                }
                if (i==99)
                {
                    Log.Info("t应该等待的循环方法执行结束了end");
                }
            }
            for (int j = 0; j < 99999999; j++)
            {
                jq++;
                if (j == 0)
                {
                    Log.Info("开始执行我们后面的j方法了");
                }
                if (j== 99999998)
                {
                    Log.Info("后面的j方法结束了end");
                }
            }
            return Json(new { code = 0, data = t, jq }, JsonRequestBehavior.AllowGet);
        }

        public int Fileup()
        {
            var file = Request.Files[0];

            var uploadfileName = file.FileName;

            string filePath = "/File/" + uploadfileName;
                        
            string AbsolutePath = Server.MapPath(filePath);
                        
            file.SaveAs(AbsolutePath);

            return 1;
        }

        public ActionResult Download(string fileName)
        {
            string path = "/File/" + fileName;
            string filePath = Server.MapPath(path);
            FileStream stream = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开   
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return Json("");

        }

        public string ImageCode(string url)
        {
            string directoryName = "/File/";
            string imageCodeName = new Random().Next() + ".png";
            string filePathName = Server.MapPath(directoryName+imageCodeName);
            QRCodeGenerator  qRCodeGenerator = new QRCoder.QRCodeGenerator();
            QRCodeData data = qRCodeGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.M);
            QRCode qRcode = new QRCode(data);
            Bitmap bitmap = qRcode.GetGraphic(15);
            bitmap.Save(filePathName, System.Drawing.Imaging.ImageFormat.Png);
            FileStream stream = new FileStream(filePathName, FileMode.Open);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string base64String = Convert.ToBase64String(bytes);
            return base64String;
       }
    }
}