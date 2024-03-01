
export default function Page({ params }: {params: {roomId: string}}) {
    return (
      <main className="flex min-h-screen flex-col items-center justify-between p-24">{params.roomId}</main>
    )
  }