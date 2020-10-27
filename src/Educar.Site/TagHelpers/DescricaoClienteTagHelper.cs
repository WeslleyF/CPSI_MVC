using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educar.Site.TagHelpers
{
    public class DescricaoClienteTagHelper : TagHelper
    {
        private readonly IConfiguration configuration; 
        public DescricaoClienteTagHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperAttribute attribute;
            string cliente = "";
            string tag = "p";

            //O parametro "tag" da tagHelper DescricaoCliente é responsável por definir com que tag a descrição do cliente será renderizado
            if (context.AllAttributes.TryGetAttribute("tag", out attribute)) tag = attribute.Value.ToString(); 

            cliente = configuration.GetValue<string>("Informacoes:DescricaoCliente");
            output.TagName = tag;
            output.Content.SetContent(cliente);

            //Removendo atributos da saída, para abastrair lógica no frontend
            output.Attributes.RemoveAll("tag");
        }
    }
}
