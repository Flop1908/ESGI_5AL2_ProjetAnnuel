//
//  AnneProduct.h
//  MultiProductViewer
//
//  Created by JN on 2014-3-18.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface AnneProduct : NSObject{
    NSDateFormatter *date;
    NSString *description;
    NSString *author;
	int entryId;
	int agreeCount;
	int deserveCount;
	int commentsCount;
}

@property (strong, nonatomic) NSString *author;
@property (strong, nonatomic) NSString *description;
@property (strong, nonatomic) NSDateFormatter *date;
@property (strong, nonatomic) NSString *voteplus;
@property (strong, nonatomic) NSString *votemoins;
@property (strong, nonatomic) NSString *point;
@property (strong, nonatomic) NSString *nbcoms;
@property (strong, nonatomic) NSString *Id;
@property (strong, nonatomic) NSNull *favorite;
@property (strong, nonatomic) NSString *type;
//@property (nonatomic, retain) int agreeCount;
//int deserveCount;//bool
//@property (strong, nonatomic) NSURL *imageURL;


/*! Creates a new instance from a dictionary.
 * \param dict A dictionary containing proper values for a given product:
 * 'name', 'details', 'identifier', and either 'imageURL' or 'imageURLString'
 */
+ (instancetype)productWithDictionary:(NSDictionary *)dict;

/*! Creates an array of new instances from an array of dictionaries. The
 * required dictionary values are the same as described for the
 * productWithDictionary: method.
 * \param array An array of specification dictionaries.
 */
+ (NSArray *)productsWithArray:(NSArray *)array;


@end
