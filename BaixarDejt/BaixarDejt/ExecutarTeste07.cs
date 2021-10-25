using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace BaixarDejt
{
    public class ExecutarTeste07
    {

        public static void Testar07()
        {
            string folderOrigem = @"C:\Pastas de Trabalho\Projetos\Processos\782BCBED96BD\Log";
            string folderOrigemB = @"C:\Pastas de Trabalho\Projetos\Processos\782BCBED96BD\Log";
            string arquivoOrigem = "";
            string folderDestino = @"C:\Lixo\Log";
            string folderDestinoB = @"C:\Lixo\Log\Teste";
            string inicialNovoNome = "";
            string novaExtensao = ".txt";
            string nomeFinalArquivo = "";
            string nomeArquivoCompactado = "lixo.zip";

            //bool testeA = CopiarArquivo(folderOrigem, arquivoOrigem, folderDestino, inicialNovoNome, novaExtensao, nomeFinalArquivo);
            bool testeB = CopiarDiretorio(folderOrigemB, folderDestinoB);

            DescompactarArquivos(folderOrigem, nomeArquivoCompactado, folderDestinoB);
            var testeC = DeletarDiretorioProcesso(folderDestinoB);
        }

        private static bool CopiarArquivo(string folderOrigem, string arquivoOrigem, string folderDestino, string inicialNovoNome, string novaExtensao, string nomeFinalArquivo)
        {
            bool retorno = false;

            try
            {
                string[] fileEntries = Directory.GetFiles(folderOrigem);
                foreach (string fileName in fileEntries)
                {
                    string novoNome = fileName.Substring(folderOrigem.Length + 1);

                    if ((!string.IsNullOrWhiteSpace(arquivoOrigem) && arquivoOrigem == novoNome) || string.IsNullOrWhiteSpace(arquivoOrigem))
                    {
                        if (!string.IsNullOrWhiteSpace(novaExtensao))
                            novoNome = $"{inicialNovoNome}{novoNome.Substring(0, novoNome.LastIndexOf("."))}";

                        int tamanho = novoNome.Length <= 100 ? novoNome.Length : 100;
                        novoNome = novoNome.Replace("/", "_").Replace(":", "_").Substring(0, tamanho);

                        if (!string.IsNullOrEmpty(nomeFinalArquivo))
                            System.IO.File.Copy(@fileName, $"{@folderDestino}\\{nomeFinalArquivo}{novaExtensao}");
                        else
                            System.IO.File.Copy(@fileName, $"{@folderDestino}\\{novoNome}{novaExtensao}");

                        retorno = true;

                        return retorno;
                    }
                }
                //=================================================================================
            }
            catch (Exception)
            {
                //bool gerouLog = _controleLog.GeraLog("0", 0, 0, ex);
            }

            return retorno;
        }

        private static bool CopiarDiretorio(string folderOrigemB, string folderDestinoB)
        {
            bool retorno = false;

            try
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(folderOrigemB, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(folderOrigemB, folderDestinoB));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(folderOrigemB, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(folderOrigemB, folderDestinoB), true);

                retorno = true;
            }
            catch (Exception ex)
            {
            }

            return retorno;
        }

        private static bool DescompactarArquivos(string folderOrigem, string nomeArquivoCompactado, string folderDestino)
        {
            bool retorno = false;
            ZipFile arquivosCompactado = null;

            try
            {
                //=================================================================================
                //cria o arquivo compactado
                //=================================================================================
                using (FileStream arquivoCompactado = File.OpenRead($"{folderOrigem}\\{nomeArquivoCompactado}"))
                {
                    arquivosCompactado = new ZipFile(arquivoCompactado);

                    foreach (ZipEntry arquivo in arquivosCompactado)
                    {
                        if (!arquivo.IsFile)
                            continue;           // Ignore directories

                        string nomeArquivo = arquivo.Name;
                        int posicaoBarra = nomeArquivo.LastIndexOf("/");
                        if (posicaoBarra > 0)
                            nomeArquivo = nomeArquivo.Substring(posicaoBarra + 1);

                        byte[] buffer = new byte[4096];     // 4K is optimum
                        Stream zipStream = arquivosCompactado.GetInputStream(arquivo);

                        using (FileStream streamWriter = File.Create($"{folderDestino}\\{nomeArquivo}"))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                    }
                    retorno = true;

                    arquivoCompactado.Close(); // Ensure we release resources
                }

            }
            catch (Exception ex)
            {
                // bool gerouLog = _controleLog.GeraLog("0", 0, 0, ex);
            }
            finally
            {
                if (arquivosCompactado != null)
                {
                    arquivosCompactado.IsStreamOwner = true; // Makes close also shut the underlying stream
                    arquivosCompactado.Close(); // Ensure we release resources
                }
            }

            return retorno;
        }





        private static string DeletarDiretorioProcesso(string pastaBase)
        {
            string retorno = "";

            Directory.SetCurrentDirectory(@"C:\");

            try
            {
                if (Directory.Exists(@pastaBase))
                    Directory.Delete(@pastaBase, true);

                retorno = $"{pastaBase}";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }


    }
}
