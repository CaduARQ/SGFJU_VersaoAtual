import { AuthProvider } from "@/components/auth-provider";
import { AppShell } from "@/components/app-shell";

export default function AreaLogadaLayout({ children }: LayoutProps<"/">) {
  return (
    <AuthProvider>
      <AppShell>{children}</AppShell>
    </AuthProvider>
  );
}
