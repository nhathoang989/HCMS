using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using HCMS.CRM.Ultilities;
using HCMS.API.DALs.CRM;
using HCMS.API.Models.CRM;

namespace HCMS.CRM.Views
{
    /// <summary>
    /// Interaction logic for CreateProductDetailsTemplate.xaml
    /// </summary>
    public partial class CreateProductDetailsTemplate : BaseDialogWindow
    {
        JArray result = new JArray();
        public CreateProductDetailsTemplate()
        {
            InitializeComponent();
            tblResult.Text = result.ToString();
            cbListTemplate.ItemsSource =  ProductDetailsTemplateDAL.GetListTemplate();
            cbListTemplate.DisplayMemberPath = "Name";
            cbListTemplate.SelectedValuePath = "Name";
            cbListTemplate.SelectedValue = "Name";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string groupName = tbGroup.Text.Trim();
            string key = tbKey.Text.Trim();
            string value = tbValue.Text.Trim();
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(groupName))
            {
                JObject jGroup = common.getJObject(groupName, result);

                if (jGroup == null)
                {
                    var newGroup = new JObject(new JProperty("name", groupName));
                    newGroup.Add(new JProperty("order", result.Count));
                    newGroup.Add(new JProperty("data", new JArray()));
                    
                    result.Add(newGroup);

                    jGroup = common.getJObject(groupName, result);
                }

                JObject obj = new JObject(new JProperty(key, value));
                JArray data = (JArray)jGroup["data"];
                data.Add(obj);
                tblResult.Text = result.ToString();
            }
            
        }

        
        private void tblResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }

        private void tblResult_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            try
            {
                var newArr = JArray.Parse(tblResult.Text);
                isValid = true;
                result = newArr;
            }
            catch
            {
                MessageBox.Show("Invalid Format");

            }
            finally {
                tblResult.Text = result.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CRM_Product_Details_Template template = new CRM_Product_Details_Template();
            template.Name = tbTempate.Text.Trim();
            template.Template = result.ToString(Newtonsoft.Json.Formatting.None).Trim();            
            ProductDetailsTemplateDAL.AddOrUpdateTemplate(template);

            MessageBox.Show("Saved");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbListTemplate_Selected(object sender, RoutedEventArgs e)
        {
            var template = ProductDetailsTemplateDAL.GetTemplate(cbListTemplate.SelectedValue.ToString());
            result = JArray.Parse(template.Template);
            result = common.sortJArray("order", result);
            tbTempate.Text = template.Name;
            tblResult.Text = result.ToString();
        }
        //bool checkJArrayContainObject(string key, JArray arr) {

        //}
    }
}
