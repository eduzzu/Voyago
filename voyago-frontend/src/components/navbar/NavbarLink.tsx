export default function NavbarLink({
  href,
  label,
}: {
  href: string;
  label: string;
}) {
  return (
    <div>
      <a
        href={href}
        className="font-medium relative py-2 text-red-700 after:content-[''] after:absolute after:w-0 after:h-[2px] after:left-0 after:-bottom-1 after:bg-red-700 after:transition-all after:duration-700 hover:after:w-full"
      >
        {label}
      </a>
    </div>
  );
}
