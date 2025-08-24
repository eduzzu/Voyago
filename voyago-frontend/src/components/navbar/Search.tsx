export default function Search() {
  return (
    <div>
        <button className="flex items-center justify-center border-1 border-gray-200 rounded-3xl bg-gray-200 px-4 py-1 font-medium cursor-pointer hover:bg-gray-300 hover:transition duration-500">
        <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        strokeWidth={1.5}
        stroke="currentColor"
        className="size-7 p-1 cursor-pointer "
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z"
        />
      </svg>
      Search
      </button>
    </div>
  )
}
