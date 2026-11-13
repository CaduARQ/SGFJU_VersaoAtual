# Pasta de dados da API

A API grava e lê aqui os arquivos de execução que o sistema antigo guardava dentro do site:
`Serializeds/` (caches e listas), `LogWebApp/` (logs), `DocumentosAutorizacao/`.

O conteúdo desta pasta não vai para o Git.

- **Desenvolvimento:** pode começar vazia. As pastas são criadas conforme o uso.
- **Produção:** aponte `Sgfju:PastaConteudoLegado` (ou a variável `Sgfju__PastaConteudoLegado`) para uma pasta com uma cópia de `SGFJU.Domain.UI/Serializeds` do servidor atual, se precisar dos caches existentes.
