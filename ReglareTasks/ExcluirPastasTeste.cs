----metodos na classe gerenciarfisicoservice

  //veras!!
        public string DeletarDiretorioProfileFireFox(ProcessamentoCaptura processo, string pastaBaseRobos)
        {
            string retorno = "";
            string macAddr = processo.EquipamentoProcessamento.Address;
            string idTask = string.Empty;
            string folderBase = pastaBaseRobos;


            foreach (var item in processo.SolicitacaoCaptura.Capturas)
            {
                idTask = item.Id.ToString();

                try
                {
                    string folderprofile = $"{folderBase}Processamento\\{macAddr}\\{idTask}";
                    if (Directory.Exists($"{folderprofile}"))
                        Directory.Delete($"{folderprofile}", true);

                    retorno = $"{folderprofile}";
                }
                catch (Exception ex)
                {
                    retorno = ex.Message;
                }

            }
            return retorno;
        }

        public string DeletarDiretorioProcesso(int processo, string macAddress, string pastaBaseRobos)
        {
            string retorno = "";
            string macAddr = macAddress;
            string idTask = processo.ToString();
            string folderBase = pastaBaseRobos;

            Directory.SetCurrentDirectory($"{folderBase}");

            try
            {
                string folderprofile = $"{folderBase}Processamento\\{macAddr}\\{idTask}";
                if (Directory.Exists($"{folderprofile}"))
                    Directory.Delete($"{folderprofile}", true);

                retorno = $"{folderprofile}";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }