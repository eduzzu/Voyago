import NavbarLink from "./NavbarLink";
import Search from "./Search";
import UserProfileNavbar from "./UserProfileNavbar";

export default function Navbar() {
  return (
    <nav className="w-11/12 h-16 flex items-center sticky top-4 bg-white border-b-2 border-gray-200 shadow-md rounded-3xl">
      <p className="w-fit px-12 text-2xl text-red-700 font-bold cursor-pointer">
        Voyago
      </p>
      
     <div className="flex justify-center w-fit mx-auto">
        <ul className="flex items-center w-fit">
          <li className="inline-block px-4">
            <NavbarLink href="/trips" label="Trips" />
          </li>
          <li className="inline-block px-4">
            <NavbarLink href="/tickets" label="Tickets" />
          </li>
          <li className="inline-block px-4">
            <NavbarLink href="/companies" label="Companies" />
          </li>
          <li className="inline-block px-4">
            <NavbarLink href="/contact" label="Contact" />
          </li>
          <li className="inline-block px-4">
            <NavbarLink href="/about-us" label="About Us" />
          </li>
        </ul>
      </div>
      <Search/>      
      <UserProfileNavbar />
    </nav>
  );
}
