export default function UserProfileNavbar() {
  return (
    <div className="flex items-center justify-center px-4 ml-auto mr-8">
        <img
            src="https://avatars.githubusercontent.com/u/55875290?v=4"
            alt="User Profile"
            className="w-10 h-10 rounded-full border-2 border-red-700 mr-2 cursor-pointer hover:scale-110 hover:transition duration-700"
            />
            <div className="flex flex-col cursor-pointer">
        <p className="text-md font-medium">Eduard</p>
        <p className="text-sm font-light">User</p>
        </div>
    </div>
  )
}

