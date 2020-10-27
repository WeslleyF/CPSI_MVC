using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educar.Site.TagHelpers
{
    public class ClienteTagHelper : TagHelper
    {
        private readonly IConfiguration configuration; 
        public ClienteTagHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperAttribute attribute;
            string cliente = "";
            string tag = "p";

            //O parametro "tag" da tagHelper Clinte é responsável por definir como que tag o nome do cliente será renderizado
            if (context.AllAttributes.TryGetAttribute("tag", out attribute)) tag = attribute.Value.ToString();

            cliente = configuration.GetValue<string>("Informacoes:Cliente");
            output.TagName = tag;
            output.Content.SetContent(cliente);

            //Removendo atributos da saída, para abastrair lógica do frontend
            output.Attributes.RemoveAll("tag");
        }
    }
}
