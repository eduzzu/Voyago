export default function FormHeader({headerH1}: {headerH1?: string}) {
  return (
    <>
      <div className="flex justify-center items-center gap-1">
        <img
          src="/src/assets/voyago.png"
          height="50%"
          className="rounded-full border-1 border-gray-300"
        />
        <h1 className="text-center text-xl">Voyago</h1>
      </div>
      <h1 className="text-center text-xl">{headerH1}</h1>
    </>
  );
}
