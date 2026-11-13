// Cliente HTTP da API SGFJU. Todas as chamadas passam por /api (proxy do Next.js),
// levando o cookie de login automaticamente.

export class ApiError extends Error {
  constructor(
    message: string,
    public status: number,
  ) {
    super(message);
  }
}

async function request<T>(method: "GET" | "POST", path: string, body?: unknown): Promise<T> {
  const res = await fetch(`/api/${path.replace(/^\/+/, "")}`, {
    method,
    credentials: "include",
    headers: body !== undefined ? { "Content-Type": "application/json" } : undefined,
    body: body !== undefined ? JSON.stringify(body) : undefined,
    cache: "no-store",
  });

  if (res.status === 401) {
    if (typeof window !== "undefined" && !window.location.pathname.startsWith("/login")) {
      const voltar = encodeURIComponent(window.location.pathname);
      // Recarga completa de propósito: limpa todo o estado da sessão anterior.
      // eslint-disable-next-line @next/next/no-location-assign-relative-destination
      window.location.href = `/login?voltar=${voltar}`;
    }
    throw new ApiError("Sessão expirada. Faça login novamente.", 401);
  }

  const text = await res.text();
  const data = text ? safeJson(text) : null;

  if (!res.ok) {
    const msg =
      (data && typeof data === "object" && ("mensagem" in data ? data.mensagem : "detail" in data ? data.detail : null)) ||
      `Erro ${res.status} ao chamar ${path}`;
    throw new ApiError(String(msg), res.status);
  }
  return data as T;
}

function safeJson(text: string): unknown {
  try {
    return JSON.parse(text);
  } catch {
    return text;
  }
}

export const api = {
  get: <T>(path: string) => request<T>("GET", path),
  post: <T>(path: string, body: unknown = {}) => request<T>("POST", path, body),
};
