#pragma once
#define XTENSOR_CS_ARRAY_HPP

#include <algorithm>
#include <cstddef>
#include <utility>
#include <vector>

#include "xtensor/xbuffer_adaptor.hpp"
#include "xtensor/xcontainer.hpp"
#include "xtensor/xiterator.hpp"
#include "xtensor/xsemantic.hpp"
#include "xtensor/xutils.hpp"

namespace xt
{
	template <class T>
	class csarray;

	template <class T>
	struct xcontainer_inner_types<csarray<T>>
	{
		using r_type = T;
		using underlying_type = r_detail::get_underlying_value_type_r<T>;
		using storage_type = xbuffer_adaptor<typename underlying_type::type*>;
		using reference = typename storage_type::reference;
		using const_reference = typename storage_type::const_reference;
		using size_type = typename storage_type::size_type;
		constexpr static int SXP = Rcpp::traits::r_sexptype_traits<T>::rtype;
		using shape_type = xt::dynamic_shape<typename storage_type::size_type>;
		using strides_type = xt::dynamic_shape<typename storage_type::difference_type>;
		using backstrides_type = xt::dynamic_shape<typename storage_type::difference_type>;

		using shape_value_type = typename Rcpp::traits::storage_type<INTSXP>::type;
		using inner_shape_type = xbuffer_adaptor<shape_value_type*>;
		using inner_strides_type = strides_type;
		using inner_backstrides_type = backstrides_type;
		using temporary_type = csarray<T>;
		static constexpr layout_type layout = layout_type::column_major;
	};

	template <class T>
	struct xiterable_inner_types<csarray<T>>
		: xcontainer_iterable_types<csarray<T>>
	{
	};

	/**
	 * @class csarray
	 * @brief Multidimensional container providing the xtensor container semantics to an R array.
	 *
	 * csarray is similar to the xarray container in that it has a dynamic dimensionality.
	 * Reshapes of a csarray container are reflected in the underlying R array.
	 *
	 * @tparam T The type of the element stored in the csarray.
	 *
	 * @sa rtensor
	 */
	template <class T>
	class csarray : public rcontainer<csarray<T>>,
		public xcontainer_semantic<csarray<T>>
	{
	public:

		using self_type = csarray<T>;
		using base_type = rcontainer<self_type>;
		using semantic_base = xcontainer_semantic<csarray<T>>;

		using inner_types = xcontainer_inner_types<self_type>;

		using underlying_type = typename inner_types::underlying_type;
		using storage_type = typename inner_types::storage_type;
		using value_type = typename storage_type::value_type;
		using reference = typename storage_type::reference;
		using const_reference = typename storage_type::const_reference;
		using pointer = typename storage_type::pointer;
		using const_pointer = typename storage_type::const_pointer;
		using size_type = typename storage_type::size_type;
		using difference_type = typename storage_type::difference_type;

		using shape_type = typename inner_types::shape_type;
		using strides_type = typename inner_types::strides_type;
		using backstrides_type = typename inner_types::backstrides_type;
		using inner_shape_type = typename inner_types::inner_shape_type;
		using inner_strides_type = typename inner_types::inner_strides_type;
		using inner_backstrides_type = typename inner_types::inner_backstrides_type;

		using iterable_base = xiterable<self_type>;

		using iterator = typename iterable_base::iterator;
		using const_iterator = typename iterable_base::const_iterator;

		using stepper = typename iterable_base::stepper;
		using const_stepper = typename iterable_base::const_stepper;

		constexpr static int SXP = Rcpp::traits::r_sexptype_traits<T>::rtype;

		csarray() = default;
		csarray(SEXP exp);

		csarray(const shape_type& shape);
		csarray(const shape_type& shape, const_reference value);

		csarray(const value_type& t);
		csarray(nested_initializer_list_t<value_type, 1> t);
		csarray(nested_initializer_list_t<value_type, 2> t);
		csarray(nested_initializer_list_t<value_type, 3> t);
		csarray(nested_initializer_list_t<value_type, 4> t);
		csarray(nested_initializer_list_t<value_type, 5> t);

		template <class S = shape_type>
		static csarray from_shape(S&& shape);

		template <class E>
		csarray(const xexpression<E>& e);

		csarray(const self_type& rhs);
		self_type& operator=(const self_type& rhs);

		csarray(self_type&&) = default;
		self_type& operator=(self_type&&) = default;

		template <class E>
		self_type& operator=(const xexpression<E>& e);

		layout_type layout() const;

		// Internal method, called when the stored SEXP changes
		void update(SEXP new_sexp) noexcept;

	private:

		storage_type m_storage;
		inner_shape_type m_shape;
		strides_type m_strides;
		strides_type m_backstrides;

		template <class S>
		void init_from_shape(const S& shape);

		const inner_shape_type& shape_impl() const noexcept;
		const inner_strides_type& strides_impl() const noexcept;
		const inner_backstrides_type& backstrides_impl() const noexcept;
		storage_type& storage_impl() noexcept;
		const storage_type& storage_impl() const noexcept;

		void update_shape_and_strides() noexcept;

		friend class xcontainer<csarray<T>>;
		friend class rcontainer<csarray<T>, Rcpp::PreserveStorage>;
	};

	/*************************
	 * csarray implementation *
	 *************************/

	 /**
	  * @name Constructors
	  */
	  //@{
	template <class T>
	inline csarray<T>::csarray(SEXP exp)
	{
		detail::check_coercion<SXP>(exp);
		base_type::rstorage::set__(Rcpp::r_cast<SXP>(exp));
	}

	template <class T>
	template <class S>
	inline void csarray<T>::init_from_shape(const S& shape)
	{
		if (shape.size() == 0)
		{
			base_type::rstorage::set__(Rf_allocVector(SXP, 1));
		}
		else
		{
			Rcpp::IntegerVector tmp_shape(shape.begin(), shape.end());
			base_type::rstorage::set__(Rf_allocArray(SXP, SEXP(tmp_shape)));
		}
	}

	/**
	 * Allocates an uninitialized csarray with the specified shape.
	 * @param shape the shape of the csarray
	 */
	template <class T>
	inline csarray<T>::csarray(const shape_type& shape)
	{
		init_from_shape(shape);
	}

	/**
	 * Allocates a csarray with the specified shape. Elements are
	 * initialized to the specified value.
	 * @param shape the shape of the csarray
	 * @param value the value of the elements
	 */
	template <class T>
	inline csarray<T>::csarray(const shape_type& shape, const_reference value)
	{
		init_from_shape(shape);
		std::fill(this->begin(), this->end(), value);
	}

	/**
	 * Allocates a csarray with nested initializer lists.
	 */
	template <class T>
	inline csarray<T>::csarray(const value_type& t)
	{
		init_from_shape(xt::shape<shape_type>(t));
		nested_copy(m_storage.begin(), t);
	}

	template <class T>
	inline csarray<T>::csarray(nested_initializer_list_t<value_type, 1> t)
	{
		init_from_shape(xt::shape<shape_type>(t));
		nested_copy(this->begin(), t);
	}

	template <class T>
	inline csarray<T>::csarray(nested_initializer_list_t<value_type, 2> t)
	{
		init_from_shape(xt::shape<shape_type>(t));
		nested_copy(this->begin(), t);
	}

	template <class T>
	inline csarray<T>::csarray(nested_initializer_list_t<value_type, 3> t)
	{
		init_from_shape(xt::shape<shape_type>(t));
		nested_copy(this->begin(), t);
	}

	template <class T>
	inline csarray<T>::csarray(nested_initializer_list_t<value_type, 4> t)
	{
		init_from_shape(xt::shape<shape_type>(t));
		nested_copy(this->begin(), t);
	}

	template <class T>
	inline csarray<T>::csarray(nested_initializer_list_t<value_type, 5> t)
	{
		init_from_shape(xt::shape<shape_type>(t));
		nested_copy(this->begin(), t);
	}

	/**
	 * Allocates and returns an csarray with the specified shape.
	 * @param shape the shape of the csarray
	 */
	template <class T>
	template <class S>
	inline csarray<T> csarray<T>::from_shape(S&& shape)
	{
		return self_type(xtl::forward_sequence<shape_type, S>(shape));
	}
	//@}

	/**
	 * @name Copy semantic
	 */
	 //@{
	 /**
	  * The copy constructor.
	  */
	template <class T>
	inline csarray<T>::csarray(const self_type& rhs)
		: base_type(rhs), semantic_base(rhs)
	{
		init_from_shape(rhs.shape());
		std::copy(rhs.storage().cbegin(), rhs.storage().cend(), this->storage().begin());
	}

	/**
	 * The assignment operator.
	 */
	template <class T>
	inline auto csarray<T>::operator=(const self_type& rhs) -> self_type&
	{
		self_type tmp(rhs);
		*this = std::move(tmp);
		return *this;
	}
	//@}

	/**
	 * @name Extended copy semantic
	 */
	 //@{
	 /**
	  * The extended copy constructor.
	  */
	template <class T>
	template <class E>
	inline csarray<T>::csarray(const xexpression<E>& e)
	{
		semantic_base::assign(e);
	}

	/**
	 * The extended assignment operator.
	 */
	template <class T>
	template <class E>
	inline auto csarray<T>::operator=(const xexpression<E>& e) -> self_type&
	{
		return semantic_base::operator=(e);
	}
	//@}

	template <class T>
	inline layout_type csarray<T>::layout() const
	{
		return layout_type::column_major;
	}

	template <class T>
	inline auto csarray<T>::shape_impl() const noexcept -> const inner_shape_type&
	{
		return m_shape;
	}

	template <class T>
	inline auto csarray<T>::strides_impl() const noexcept -> const inner_strides_type&
	{
		return m_strides;
	}

	template <class T>
	inline auto csarray<T>::backstrides_impl() const noexcept -> const inner_backstrides_type&
	{
		return m_backstrides;
	}

	template <class T>
	inline auto csarray<T>::storage_impl() noexcept -> storage_type&
	{
		return m_storage;
	}

	template <class T>
	inline auto csarray<T>::storage_impl() const noexcept -> const storage_type&
	{
		return m_storage;
	}

	template <class T>
	inline void csarray<T>::update(SEXP new_sexp) noexcept
	{
		this->m_shape = detail::r_shape_to_buffer_adaptor(new_sexp);
		resize_container(m_strides, m_shape.size());
		resize_container(m_backstrides, m_shape.size());
		std::size_t sz = xt::compute_strides<layout_type::column_major>(m_shape, layout_type::column_major, m_strides, m_backstrides);
		this->m_storage = storage_type(reinterpret_cast<value_type*>(Rcpp::internal::r_vector_start<SXP>(new_sexp)), sz);
	}

	template <class T>
	inline void csarray<T>::update_shape_and_strides() noexcept
	{
		m_shape = detail::r_shape_to_buffer_adaptor(*this);
		xt::compute_strides<layout_type::column_major>(m_shape, layout_type::column_major, m_strides, m_backstrides);
	}
}

namespace Rcpp
{
	template <typename T>
	inline SEXP wrap(const xt::csarray<T>& arr)
	{
		return SEXP(arr);
	}
}