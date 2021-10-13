using Ailos.Common.Model;
using System;

namespace Ailos.Autentication.DTO.Request
{
    public enum TipoAutenticacao
    {
        Senha = 1,
        TouchId = 2,
        FaceId = 3
    }
    public class Device : Account
    {
        public long DispositivoMobileId { get; set; }
        public string AplicacaoId { get; set; }
        public string InstalacaoId { get; set; }
        public string Modelo { get; set; }
        public string Plataforma { get; set; }
        public string VersaoSO { get; set; }
        public string VersaoAplicativo { get; set; }
        public string HashId { get; set; }
        public short Autorizado { get; set; }
        public short? LocalizacaoHabilitada { get; set; }
        public short? PushHabilitado { get; set; }
        public string TokenDispositivoFCM { get; set; }
        public short TipoAutenticacao { get; set; }
        public TipoAutenticacao TipoAutenticacaoEnum
        {
            get { return (TipoAutenticacao)TipoAutenticacao; }
        }
        public DateTime? DataUltimoAcesso { get; set; }
    }
}
