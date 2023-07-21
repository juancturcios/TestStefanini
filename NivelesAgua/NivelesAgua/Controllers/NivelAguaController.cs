using Microsoft.AspNetCore.Mvc;

namespace NivelesAguaController.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class NivelAguaController : ControllerBase
	{
		private readonly ILogger<NivelAguaController> _logger;
		[HttpPost("GetResult")]
		public int GetItems(int[] arreglo)
		{
			int longitudArreglo = arreglo.Length;
			int[] izquierda = new int[longitudArreglo];
			int[] derecha = new int[longitudArreglo];
			int[] agua = new int[longitudArreglo];
			int contador = 0;
			for (int i = 0; i < longitudArreglo; i++)
			{
				if(i==0)
				{
					izquierda[i] = 0;
				}
				else
				{
					izquierda[i] = Math.Max(arreglo[i], izquierda[i - 1]);
				}
			}

			for (int i = (longitudArreglo-1); i >= 0; i--)
			{
				if (i == longitudArreglo-1)
				{
					derecha[i] = 0;
				}
				else
				{
					derecha[i] = Math.Max(arreglo[i], derecha[i + 1]);
				}
			}

			for (int i = 0; i < longitudArreglo; i++)
			{
				agua[i] = Math.Min(izquierda[i], derecha[i]) - arreglo[i];
				agua[i]= (agua[i]<0)? 0 : agua[i];
				contador += agua[i];
			}

			return contador;
		}
		
	}
}
