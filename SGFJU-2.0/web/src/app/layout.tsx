import type { Metadata } from "next";
// Fonte Geist empacotada via npm (não depende do Google Fonts no build).
import { GeistSans } from "geist/font/sans";
import { GeistMono } from "geist/font/mono";
import "./globals.css";


export const metadata: Metadata = {
  title: { default: "SGFJU", template: "%s · SGFJU" },
  description: "Sistema de Gestão da Força Jovem Universal",
};

export default function RootLayout({ children }: LayoutProps<"/">) {
  return (
    <html lang="pt-BR" className={`${GeistSans.variable} ${GeistMono.variable} h-full antialiased`}>
      <body className="min-h-full font-sans">{children}</body>
    </html>
  );
}
