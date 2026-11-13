import type { NextConfig } from "next";

// Endereço da API ASP.NET Core (.NET 10). Em produção, defina SGFJU_API_URL.
const apiUrl = process.env.SGFJU_API_URL ?? "http://localhost:5080";

const nextConfig: NextConfig = {
  cacheComponents: true,
  partialPrefetching: true,
  turbopack: {
    rules: {
      "*.css": {
        loaders: ["@tailwindcss/turbopack"],
        as: "*.css",
      },
    },
  },
  // O navegador fala só com o Next.js; /api/* é repassado para a API .NET.
  // Assim o cookie de login fica no mesmo domínio e não é preciso liberar CORS.
  async rewrites() {
    return [{ source: "/api/:path*", destination: `${apiUrl}/api/:path*` }];
  },
};

export default nextConfig;
