import FooterLink from "./FooterLink";
import SocialLinks from "./SocialLinks";

export default function Footer() {
  return (
    <div className="w-full h-auto bg-gray-200 flex justify-center mt-auto border-t-gray-200 rounded-t-2xl">
      <ul className="grid grid-cols-1 md:grid-cols-6 gap-8 w-full px-16">
        <li className="w-full h-fit py-4 flex flex-col items-start">
          <h1 className="text-lg font-medium mb-2 text-red-700">Voyago</h1>
          <p className="text-sm">
            Voyago is a modern transport booking app designed to provide users
            with a fast and intuitive experience for finding and managing trips.
          </p>
        </li>
        <li className="w-full h-fit py-4 flex flex-col items-start">
          <h1 className="text-lg font-medium mb-2 text-red-700">Book a trip</h1>
          <FooterLink content="Trip 1 - Trip 2" />
          <FooterLink content="Trip 1 - Trip 3" />
          <FooterLink content="Trip 2 - Trip 5" />
          <FooterLink content="Trip 2 - Trip 4" />
          <FooterLink content="Trip 3 - Trip 1" />
        </li>
        <li className="w-full h-fit py-4 flex flex-col items-start">
          <h1 className="text-lg font-medium mb-2 text-red-700">Navigate</h1>
          <FooterLink content="My Trips" />
          <FooterLink content="My Tickets" />
          <FooterLink content="Search" />
          <FooterLink content="Companies" />
          <FooterLink content="My Profile" />

        </li>
        <li className="w-full h-fit py-4 flex flex-col items-start">
          <h1 className="text-lg font-medium mb-2 text-red-700">Help</h1>
          <FooterLink content="About Us" />
          <FooterLink content="Contact" />
        </li>
        <li className="w-full h-fit py-4 flex flex-col items-start">
          <h1 className="text-lg font-medium mb-2 text-red-700 px-3">Social</h1>
          <SocialLinks />
        </li>
        <li className="w-full h-fit py-4 flex flex-col items-start">
          <h1 className="text-lg font-medium mb-2 text-red-700">Be careful</h1>
          <p className="text-sm">
            At Voyago, we care about your online safety. Watch out for scams and
            make sure you interact only with verified sources and offers.
          </p>
        </li>
      </ul>
    </div>
  );
}
